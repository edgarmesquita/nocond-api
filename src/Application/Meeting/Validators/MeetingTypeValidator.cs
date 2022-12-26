using FluentValidation;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Validators
{
    public class MeetingTypeValidator : AbstractValidator<MeetingTypeRequest>
    {
        public MeetingTypeValidator()
        {
            RuleFor(o => o.Name)
               .MinimumLength(2)
               .MaximumLength(10);

            RuleFor(o => o.Description)
                .MinimumLength(0)
                .MaximumLength(200);
        }
    }
}
