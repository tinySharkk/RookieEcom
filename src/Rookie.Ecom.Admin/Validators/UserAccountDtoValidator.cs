using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;


namespace Rookie.Ecom.Admin.Validators
{
    public class UserAccountDtoValidator : BaseValidator<UserAccountDto>
    {
        public UserAccountDtoValidator(IUserAccountService userAccountService)
        {
            RuleFor(m => m.Id)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.UserName)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.UserName)));

            RuleFor(m => m.Password)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Password)));

            RuleFor(m => m.UserId)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.UserId)));
        }
    }
}
