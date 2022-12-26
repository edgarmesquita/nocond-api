using FluentValidation;
using NoCond.Application.Person.Models;

namespace NoCond.Application.Person.Validators
{
    public class AddressValidator : AbstractValidator<AddressRequest>
    {
        public AddressValidator()
        {
            RuleFor(o => o.Address1)
                .MinimumLength(5)
                .MaximumLength(300);

            RuleFor(o => o.Address2)
                .MinimumLength(0)
                .MaximumLength(300);

            RuleFor(o => o.PostalCode)
                .MinimumLength(3)
                .MaximumLength(10);

            RuleFor(o => o.City)
                .MinimumLength(2)
                .MaximumLength(150);

            RuleFor(o => o.State)
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
