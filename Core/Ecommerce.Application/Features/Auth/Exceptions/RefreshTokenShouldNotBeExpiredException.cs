using Ecommerce.Application.Bases;

namespace Ecommerce.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException 
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Session expired.Please log in again") { }

    }
}
