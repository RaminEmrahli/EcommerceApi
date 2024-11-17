using Ecommerce.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException : BaseExceptions 
    {
        public ProductTitleMustNotBeSameException():base("Title already exists") { }
        
    }
}
