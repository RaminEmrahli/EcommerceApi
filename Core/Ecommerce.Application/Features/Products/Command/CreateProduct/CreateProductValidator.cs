﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x=>x.Title).
                NotEmpty().
                WithName("Basliq");

            RuleFor(x=>x.Description).
                NotEmpty().
                WithName("Aciqlama");
            
            
            RuleFor(x=>x.BrandId).
                GreaterThan(0).
                WithName("Marka");

            RuleFor(x=>x.Discount).
                GreaterThanOrEqualTo(0).
                WithName("Endirim faizi");

            RuleFor(x => x.Price).
                GreaterThan(0).
                WithName("Qiymət");

            RuleFor(x => x.CategoryIds).
                NotEmpty().
                Must(categories => categories.Any()).
                WithName("Kateqoriyalar");
        }
    }
}
