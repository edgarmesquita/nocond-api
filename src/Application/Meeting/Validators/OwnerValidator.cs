using System;
using FluentValidation;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Meeting.Validators
{
    public class OwnerValidator : AbstractValidator<OwnerRequest>
    {
        public OwnerValidator()
        {
            RuleFor(o => o.PersonId)
                .NotNull()
                .NotEmpty()
                .NotEqual(default(Guid));

            RuleFor(o => o.UnitId)
                .NotNull()
                .NotEmpty()
                .NotEqual(default(Guid));

            RuleFor(o => o.OwnerTypeId)
                .NotNull()
                .NotEmpty()
                .NotEqual(default(Guid));
        }
    }
}
