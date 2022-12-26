using System;
using FluentValidation;
using Lamar;

namespace NoCond.Application.Base.Validators
{
    /// <summary>
    /// Validator Factory
    /// </summary>
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorFactory"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ValidatorFactory(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Gets the validator for the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IValidator&lt;T&gt;.</returns>
        public IValidator<T> GetValidator<T>()
        {
            return container.TryGetInstance<IValidator<T>>();
        }

        /// <summary>
        /// Gets the validator for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IValidator.</returns>
        public IValidator GetValidator(Type type)
        {
            return (IValidator)container.TryGetInstance(type);
        }
    }
}