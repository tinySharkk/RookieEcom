using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System.Text.RegularExpressions;


namespace Rookie.Ecom.Admin.Validators
{
    public class UserDtoValidator : BaseValidator<UserDto>
    {
        public UserDtoValidator(IUserService userService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.FirstName)
                .NotNull().
                WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.FirstName)));

            RuleFor(m => m.FirstName)
                .MaximumLength(ValidationRules.UserRules.MaxFirstName)
                .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.UserRules.MaxFirstName));

            RuleFor(m => m.LastName)
                .NotNull().
                WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.LastName)));

            RuleFor(m => m.LastName)
                .MaximumLength(ValidationRules.UserRules.MaxLastName)
                .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.UserRules.MaxLastName));

            RuleFor(m => m.Gender)
                .NotNull().
                WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Gender)));


            RuleFor(x => x).MustAsync(
             async (dto, cancellation) =>
             {
                 var exit = await userService.GetByIdAsync(dto.Id);
                 return exit == null || exit.Id != dto.Id;
             }
          ).WithMessage("Duplicate record");
        }
    }
    public class UserInfoDtoValidator : BaseValidator<UserInfoDto>
    {
        public UserInfoDtoValidator(IUserService userService)
        {
            Regex rxIsOnlyNumber = new Regex(@"^[0-9]*$");

            RuleFor(m => m.Id)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.FirstName)
                .NotNull().
                WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.FirstName)));

            RuleFor(m => m.FirstName)
                .MaximumLength(ValidationRules.UserRules.MaxFirstName)
                .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.UserRules.MaxFirstName));

            RuleFor(m => m.LastName)
                .NotNull().
                WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.LastName)));

            RuleFor(m => m.LastName)
                .MaximumLength(ValidationRules.UserRules.MaxLastName)
                .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.UserRules.MaxLastName));

            RuleFor(m => m.Gender)
                .NotNull().
                WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Gender)));

            RuleFor(m => m.PhoneNumber).Matches("^[0-9]*$");

            /*            RuleFor(x => x).MustAsync(
                         async (dto, cancellation) =>
                         {
                             var exit = await addressService.GetByIdAsync(dto.Id);
                             return exit == null || exit.Id == dto.Id;
                         }
                         ).WithMessage("Duplicate record");*/

        }
    }

}
