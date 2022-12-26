using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eQuantic.Core.Data.Repository;
using eQuantic.Core.Linq.Sorter;
using eQuantic.Core.Linq.Specification;
using FluentValidation;
using NoCond.Application.Base.Exceptions;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Models;
using NoCond.Application.Base.Providers.Interfaces;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Base.Specifications;

namespace NoCond.Application.Base.Services
{
    /// <summary>
    /// Referenced Only One Service Base.
    /// </summary>
    /// <typeparam name="TModel">The type of the t model.</typeparam>
    /// <typeparam name="TRequestDto">The type of the t request dto.</typeparam>
    /// <typeparam name="TDto">The type of the t dto.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    public abstract class OnlyOneServiceBase<TModel, TRequestDto, TDto, TKey> :
        WriteServiceBase<TModel, TRequestDto>, IOnlyOneService<TRequestDto, TDto>
        where TModel : HistoryMetadata, IEntity, new()
        where TDto : class, new()
    {
        /// <summary>
        /// The repository
        /// </summary>
        protected readonly IAsyncRelationalRepository<IMainUnitOfWork, TModel, TKey> Repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnlyOneServiceBase{TModel, TRequestDto, TDto, TKey}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="datetimeProvider">The datetime provider.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="validatorFactory">The validator factory.</param>
        protected OnlyOneServiceBase(
            IMainUnitOfWork unitOfWork,
            IDatetimeProvider datetimeProvider,
            IMapper mapper,
            IValidatorFactory validatorFactory
        ) : base(mapper, validatorFactory)
        {
            UnitOfWork = unitOfWork;
            DatetimeProvider = datetimeProvider;
            this.Repository = unitOfWork.GetAsyncRelationalRepository<TModel, TKey>();
        }

        /// <summary>
        /// Gets the datetime provider service.
        /// </summary>
        /// <value>The datetime provider service.</value>
        protected IDatetimeProvider DatetimeProvider { get; }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        protected IMainUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// create as an asynchronous operation.
        /// </summary>
        /// <param name="userId">The user that performed the request</param>
        /// <param name="requestDto">The request object</param>
        /// <exception cref="ConflictException">The entity already exists</exception>
        public async Task CreateAsync(Guid userId, TRequestDto requestDto)
        {
            await ValidateAsync(requestDto);

            await AfterValidationOnCreateAsync(requestDto);

            var model = await CreateModelFromRequestDtoAsync(userId, requestDto);

            await BeforeCreateAsync(requestDto, model);

            await Save(userId, model);
        }

        /// <summary>
        /// Gets the item asynchronous
        /// </summary>
        /// <param name="loadedProperties">Child entities to load</param>
        /// <returns>Task&lt;TDto&gt;.</returns>
        public async Task<TDto> GetAsync(params string[] loadedProperties)
        {
            var model = await Repository.GetFirstAsync(GetActiveEntitySpecification(),
                new ISorting[] { new Sorting<TModel>(c => c.CreatedOn, SortDirection.Descending) },
                GetPropertiesToLoad(loadedProperties));

            if (model == null)
            {
                throw new NoDataFoundException();
            }
            var dto = Mapper.Map<TDto>(model);

            return dto;
        }

        /// <summary>
        /// Gets the active entity specification.
        /// </summary>
        /// <returns>ISpecification&lt;TModel&gt;.</returns>
        protected virtual ISpecification<TModel> GetActiveEntitySpecification()
        {
            return new ActiveItemHistorySpecification<TModel>();
        }

        private async Task<TModel> CreateModelFromRequestDtoAsync(Guid userId, TRequestDto requestDto)
        {
            var model = await AdaptRequestDtoAsync(requestDto);

            var currentDateTime = DatetimeProvider.GetUtcNow();
            model.CreatedById = userId;
            model.LastUpdatedById = userId;
            model.CreatedOn = currentDateTime;
            model.LastUpdatedOn = currentDateTime;

            return model;
        }

        private async Task Save(Guid userId, TModel model, params string[] loadedProperties)
        {
            var activeModels = (await Repository.AllMatchingAsync(GetActiveEntitySpecification(),
                GetPropertiesToLoad(loadedProperties))).ToList();

            try
            {
                foreach (var activeModel in activeModels)
                {
                    activeModel.EndedById = userId;
                    activeModel.EndedOn = model.CreatedOn;

                    await Repository.ModifyAsync(activeModel);
                }

                await Repository.AddAsync(model);
                await Repository.UnitOfWork.CommitAsync();
            }
            catch (Exception ex) when (ex.InnerException is SqlException sqlEx)
            {
                if (sqlEx.Number == DuplicateEntriesErrorCode)
                {
                    throw new ConflictException("The entity already exists", ex);
                }

                throw;
            }
        }
    }
}