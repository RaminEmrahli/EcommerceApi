using Ecommerce.Application.Bases;
using Ecommerce.Application.Features.Auth.Rules;
using Ecommerce.Application.Interfaces.AutoMapper;
using Ecommerce.Application.Interfaces.Tokens;
using Ecommerce.Application.Interfaces.UnitOfWorks;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Ecommerce.Application.Features.Auth.Command.Login
{
    internal class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;

        public LoginCommandHandler(AuthRules authRules,UserManager<User> userManager,IConfiguration configuration,ITokenService tokenService,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules=authRules;
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);
            
            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);
            
            IList<string>? roles = await userManager.GetRolesAsync(user);
            
            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();
            
            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
            
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime= DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token= new JwtSecurityTokenHandler().WriteToken(token);
            await userManager.SetAuthenticationTokenAsync(user, "Default", "Access token", _token);
            return new LoginCommandResponse()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration=token.ValidTo
            };
        }
    }
}
