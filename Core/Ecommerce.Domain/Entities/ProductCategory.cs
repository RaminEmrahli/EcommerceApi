using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ProductCategory : EntityBase 
    {
        public required int ProductId { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
