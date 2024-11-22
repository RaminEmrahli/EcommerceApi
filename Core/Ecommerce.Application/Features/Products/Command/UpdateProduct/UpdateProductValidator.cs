using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommandRequest> 
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).
                GreaterThan(0);

            RuleFor(x => x.Title).
                NotEmpty().
                WithName("Basliq");

            RuleFor(x => x.Description).
                NotEmpty().
                WithName("Aciqlama");


            RuleFor(x => x.BrandId).
                GreaterThan(0).
                WithName("Marka");

            RuleFor(x => x.Discount).
                GreaterThanOrEqualTo(0).
                WithName("Endirim faizi");

            RuleFor(x => x.Price).
                GreaterThan(0).
                WithName("Qiymet");

            RuleFor(x => x.CategoryIds).
                NotEmpty().
                Must(categories => categories.Any()).
                WithName("Kateqoriyalar");

        }
    }
}
