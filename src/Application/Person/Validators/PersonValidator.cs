using FluentValidation;
using NoCond.Application.Person.Models;

namespace NoCond.Application.Person.Validators
{
    public class PersonValidator : AbstractValidator<PersonRequest>
    {
        public PersonValidator()
        {
            RuleFor(o => o.Name)
                .MinimumLength(5)
                .MaximumLength(250);

            RuleFor(o => o.Email)
                .EmailAddress();

            RuleFor(o => o.PhoneNumber)
                .NotNull()
                .NotEmpty();

            RuleFor(o => o.MobilePhoneNumber)
                .NotNull()
                .NotEmpty();

            RuleFor(o => o.Nickname)
                .NotNull()
                .NotEmpty();

            RuleFor(o => o.TaxNumber)
                .NotNull()
                .NotEmpty();

            RuleFor(o => o.IdNumber)
                .NotNull()
                .NotEmpty();
        }
    }
}
