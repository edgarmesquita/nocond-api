using System;
using FluentValidation;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Validators
{
    public class MeetingValidator : AbstractValidator<MeetingRequest>
    {
        public MeetingValidator()
        {
            RuleFor(o => o.Name)
                .MinimumLength(5)
                .MaximumLength(200);

            RuleFor(o => o.Description)
                .MinimumLength(0)
                .MaximumLength(200);

            RuleFor(o => o.MeetingTypeId)
                .NotNull()
                .NotEmpty()
                .NotEqual(default(Guid));

            RuleFor(o => o.StartsOn)
               .NotNull()
               .NotEmpty()
               .GreaterThanOrEqualTo(o => o.StartsOn);

            RuleFor(o => o.EndsOn)
                .NotNull()
                .NotEmpty()
                .LessThanOrEqualTo(o => o.StartsOn);
        }
    }
}