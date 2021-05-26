using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.Catalog.Products
{
    public class ProductCreateRequestValidator :AbstractValidator<ProductCreateRequest>
    {
        public ProductCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(200).WithMessage("Name can not over 200 characters"); ;
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.");
            RuleFor(x => x.OriginalPrice).NotEmpty().WithMessage("Original price is required.");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Details is required.");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Inventory is required.");
        }
    }
}
