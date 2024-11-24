using Ecommerce.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Auth.Exceptions
{
    public class EmailShouldBeValidException : BaseException
    {
        public EmailShouldBeValidException() : base("User not found")
        {
        }
    }
}
