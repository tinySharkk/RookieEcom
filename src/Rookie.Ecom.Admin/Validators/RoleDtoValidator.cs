using FluentValidation;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;


namespace Rookie.Ecom.Admin.Validators
{
    public class RoleDtoValidator : BaseValidator<RoleDto>
    {
        public RoleDtoValidator (IRoleService roleService)
        {
            RuleFor(m => m.Id)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Id)));

            RuleFor(m => m.RoleName)
              .NotNull()
              .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.RoleName)));
        }
    }
}
