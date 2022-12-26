using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using eQuantic.Core.Data.Repository;
using FluentValidation;
using NoCond.Application.Base.Services.Interfaces;

namespace NoCond.Application.Base.Services
{
    /// <summary>
    /// Write service base.
    /// </summary>
    /// <seealso cref="IApplicationService" />
    public class WriteServiceBase<TModel, TRequestDto> : IApplicationService
    where TModel : class, IEntity, new()
    {
        protected readonly IMapper Mapper;
        protected readonly IValidatorFactory ValidatorFactory;
        /// <summary>
        /// The duplicate entries error code
        /// </summary>
        protected const int DuplicateEntriesErrorCode = 2601;

        /// <summary>
        /// Initializes a new instance of the <see cref="WriteServiceBase"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="validatorFactory">The validator factory.</param>
        public WriteServiceBase(IMapper mapper, IValidatorFactory validatorFactory)
        {
            Mapper = mapper;
            ValidatorFactory = validatorFactory;
        }

        /// <summary>
        /// Adapts the request DTO to model.
        /// </summary>
        /// <param name="requestDto">The request dto.</param>
        /// <returns></returns>
        protected virtual Task<TModel> AdaptRequestDtoAsync(TRequestDto requestDto)
        {
            return Task.FromResult(Mapper.Map<TModel>(requestDto));
        }

        /// <returns></returns>
        protected virtual Task<TModel> AdaptRequestDtoAsync(TRequestDto requestDto, TModel model)
        {
            return Task.FromResult(Mapper.Map(requestDto, model));
        }

        /// <summary>
        /// Allows the inherited class to inject code after the dto was validated
        /// </summary>
        protected virtual Task AfterValidationOnCreateAsync(TRequestDto requestDto)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Allows the inherited class to inject code after the dto was validated
        /// </summary>
        protected virtual Task AfterValidationOnUpdateAsync(TRequestDto requestDto)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Before create model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        protected virtual Task BeforeCreateAsync(TRequestDto requestDto, TModel model)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Before delete model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        protected virtual Task BeforeDeleteAsync(TModel model)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Before delete model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        protected virtual Task BeforeDeleteAsync(IEnumerable<TModel> model)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Allows the inherited class to inject code after the model was get
        /// </summary>
        protected virtual Task BeforeUpdateAsync(TModel dbModel, TRequestDto requestDto)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the default properties to load.
        /// </summary>
        /// <returns></returns>
        protected virtual string[] GetPropertiesToLoad(params string[] loadedProperties)
        {
            var propList = loadedProperties == null ? new List<string>() : loadedProperties.ToList();
            return propList.ToArray();
        }

        /// <summary>
        /// Validates the request DTO
        /// </summary>
        /// <param name="item">item to validate</param>
        /// <param name="cancellationToken">Task cancellation token</param>
        /// <returns></returns>
        protected async Task ValidateAsync(TRequestDto item, CancellationToken cancellationToken = default)
        {
            var validator = ValidatorFactory.GetValidator<TRequestDto>();

            if (validator == null) return;

            var result = await validator.ValidateAsync(item, cancellationToken);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}