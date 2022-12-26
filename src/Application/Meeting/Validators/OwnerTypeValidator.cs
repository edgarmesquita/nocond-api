using FluentValidation;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Meeting.Validators
{
    public class OwnerTypeValidator : AbstractValidator<OwnerTypeRequest>
    {
        public OwnerTypeValidator()
        {
            RuleFor(o => o.Name)
                .MinimumLength(3)
                .MaximumLength(200);
        }
    }
}
