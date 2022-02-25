using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;


namespace Rookie.Ecom.Admin.Validators
{
    public class OrderItemDtoValidator : BaseValidator<OrderItemInfoDto>
    {
        public OrderItemDtoValidator (IOrderService orderService)
        {
            RuleFor(m => m.Id)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.OrderId)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.OrderId)));

            RuleFor(m => m.ProductId)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.ProductId)));

            RuleFor(m => m.Price)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Price)));

            RuleFor(m => m.Quantity)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Quantity)));
        }
    }
}
