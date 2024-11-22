using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest> 
    {
        public RegisterCommandValidator()
        {
            RuleFor(x=>x.FullName).
                NotEmpty().
                MaximumLength(50).
                MinimumLength(2).
                WithName("Ad,Soyad");

            RuleFor(x=>x.Email).
                NotEmpty().
                MaximumLength(60).
                MinimumLength(8).
                EmailAddress().
                WithName("E-poçt adresi");
            
            RuleFor(x => x.Password).
                NotEmpty().
                MinimumLength(6).
                WithName("Şifrə");
            
            RuleFor(x => x.ConfirmPassword).
                NotEmpty().
                MinimumLength(6).
                Equal(x => x.Password).
                WithName("Şifrəni təkrarla");
        }
    }
}
