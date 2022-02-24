using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;


namespace Rookie.Ecom.Admin.Validators
{
    public class UserDtoValidator : BaseValidator<UserDto>
    {
        public UserDtoValidator(IUserService addressService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m=>m.FirstName)
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
                 var exit = await addressService.GetByIdAsync(dto.Id);
                 return exit == null || exit.Id != dto.Id;
             }
          ).WithMessage("Duplicate record");
        }
    }
    public class UserCreateDtoValidator : BaseValidator<UserCreateDto>
    {
        public UserCreateDtoValidator(IUserService addressService)
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
                 var exit = await addressService.GetByIdAsync(dto.Id);
                 return exit == null || exit.Id == dto.Id;
             }
             ).WithMessage("Duplicate record");

        }
    }

    public class UserUpdateDtoValidator : BaseValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator(IUserService addressService)
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
        }
    }
}
