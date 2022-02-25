using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;


namespace Rookie.Ecom.Admin.Validators
{
    public class OrderDtoValidator : BaseValidator<OrderInfoDto>
    {
       public OrderDtoValidator (IOrderService orderService)
        {
            RuleFor(m => m.Id)
               .NotNull()
               .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m=>m.ProductId)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.ProductId)));

            RuleFor(m => m.ShippingAdressId)
               .NotNull()
               .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.ShippingAdressId)));
        }
    }
}
