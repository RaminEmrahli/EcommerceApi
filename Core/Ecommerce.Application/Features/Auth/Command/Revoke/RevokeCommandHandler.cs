using Ecommerce.Application.Bases;
using Ecommerce.Application.Features.Auth.Rules;
using Ecommerce.Application.Interfaces.AutoMapper;
using Ecommerce.Application.Interfaces.UnitOfWorks;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;

        public RevokeCommandHandler(UserManager<User> userManager,AuthRules authRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
        }

        async Task<Unit> IRequestHandler<RevokeCommandRequest, Unit>.Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            await authRules.EmailShouldBeValid(user);
            
            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
            
            return Unit.Value;
        }
    }
}
