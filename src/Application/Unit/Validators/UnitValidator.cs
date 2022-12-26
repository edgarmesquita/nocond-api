using FluentValidation;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Validators
{
    public class UnitValidator : AbstractValidator<UnitRequest>
    {
        public UnitValidator()
        {
            RuleFor(o => o.Code)
                .NotNull().NotEmpty();
        }
    }
}