using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;


namespace Rookie.Ecom.Admin.Validators
{
    public class ProductDtoValidator : BaseValidator<ProductInfoDto>
    {
        public ProductDtoValidator(IProductService productService)
        {
            RuleFor(m => m.Id)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.Name)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Name)));

            RuleFor(m => m.Desc)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Desc)));
        }
    }
}
