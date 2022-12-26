using FluentValidation;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Validators
{
    public class UnitRangeValidator: AbstractValidator<UnitRangeRequest>
    {
        public UnitRangeValidator()
        {
            RuleFor(o => o.CodeStart)
                .GreaterThan(0)
                .LessThan(o => o.CodeEnd);

            RuleFor(o => o.CodeEnd)
                .GreaterThan(0)
                .GreaterThan(o => o.CodeStart);
        }
    }
}