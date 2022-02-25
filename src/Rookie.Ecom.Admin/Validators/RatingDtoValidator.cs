using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;


namespace Rookie.Ecom.Admin.Validators
{
    public class RatingDtoValidator : BaseValidator<RatingInfoDto>
    {
        public RatingDtoValidator(IRatingService ratingService)
        {
            RuleFor(m => m.Id)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.UserId)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.UserId)));

            RuleFor(m => m.ProductId)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.ProductId)));

            RuleFor(m => m.Star)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Star)));
        }
    }
}
