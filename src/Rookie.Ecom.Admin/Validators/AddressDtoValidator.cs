using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;


namespace Rookie.Ecom.Admin.Validators
{
    public class AddressDtoValidator : BaseValidator<AddressDto>
    {
        public AddressDtoValidator(IAddressService addressService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.AddressLine)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AddressLine)));

            RuleFor(m => m.AddressLine)
               .MaximumLength(ValidationRules.AddressRules.MaxAddressLine)
               .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.AddressRules.MaxAddressLine))
               .When(m => !string.IsNullOrWhiteSpace(m.AddressLine));


            RuleFor(x => x).MustAsync(
             async (dto, cancellation) =>
             {
                 var exit = await addressService.GetByIdAsync(dto.Id);
                 return exit == null || exit.Id != dto.Id;
             }
          ).WithMessage("Duplicate record");
        }
    }
    public class AddressInfoDtoValidator : BaseValidator<AddressInfoDto>
    {
        public AddressInfoDtoValidator(IAddressService addressService)
        {
            RuleFor(m => m.Id)
                 .NotNull()
                 .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.AddressLine)
                  .NotEmpty()
                  .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AddressLine)));

            RuleFor(m => m.AddressLine)
               .MaximumLength(ValidationRules.AddressRules.MaxAddressLine)
               .WithMessage(string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.AddressRules.MaxAddressLine))
               .When(m => !string.IsNullOrWhiteSpace(m.AddressLine));


            RuleFor(x => x).MustAsync(
             async (dto, cancellation) =>
             {
                 var exit = await addressService.GetByIdAsync(dto.Id);
                 return exit == null || exit.Id == dto.Id;
             }
          ).WithMessage("Duplicate record");
        }
    }

}
