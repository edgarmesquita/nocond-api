using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eQuantic.Core.Collections;
using eQuantic.Core.Data.Repository;
using eQuantic.Core.Linq.Specification;
using FluentValidation;
using NoCond.Application.Base.Exceptions;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Models;
using NoCond.Application.Base.Providers.Interfaces;
using NoCond.Application.Base.Services.Interfaces;

namespace NoCond.Application.Base.Services
{
    /// <summary>
    /// Referenced Crud service base.
    /// </summary>
    /// <seealso cref="CrudServiceBase<TModel, TRequestDto, TDto, TKey>" />
    public class CrudServiceBase<TModel, TRequestDto, TDto, TKey, TReferenceKey> : CrudServiceBase<TModel, TRequestDto, TDto, TKey>, ICrudService<TRequestDto, TDto, TKey, TReferenceKey>
        where TModel : class, IEntity, IEntityBase<TKey>, new()
        where TRequestDto : IReferencedRequestBase<TReferenceKey>
        where TDto : class, new()
    {
        protected CrudServiceBase(
            IMainUnitOfWork unitOfWork,
            IDatetimeProvider datetimeProvider,
            IMapper mapper,
            IValidatorFactory validatorFactory) : base(unitOfWork, datetimeProvider, mapper, validatorFactory) { }

        public virtual Task<TKey> CreateAsync(TReferenceKey referenceId, Guid userId, TRequestDto request)
        {
            request.SetReferenceId(referenceId);
            return base.CreateAsync(userId, request);
        }

        public virtual Task DeleteAsync(TReferenceKey referenceId, TKey id, Guid userId, params string[] loadedProperties)
        {
            return base.DeleteAsync(id, userId, loadedProperties);
        }

        public virtual Task<TDto> GetAsync(TReferenceKey referenceId, TKey id, params string[] loadedProperties)
        {
            return base.GetAsync(id, loadedProperties);
        }

        public virtual Task<IPagedEnumerable<TDto>> GetAsync(TReferenceKey referenceId, ReferencedPagedListRequest<TReferenceKey> request)
        {
            request.SetReferenceId(referenceId);
            return base.GetAsync(request);
        }

        public Task<IEnumerable<TDto>> GetAsync(TReferenceKey referenceId, params string[] loadedProperties)
        {
            return base.GetAsync(loadedProperties);
        }

        public virtual Task UpdateAsync(TReferenceKey referenceId, TKey id, Guid userId, TRequestDto requestDto, params string[] loadedProperties)
        {
            return base.UpdateAsync(id, userId, requestDto, loadedProperties);
        }
    }
    /// <summary>
    /// Crud service base.
    /// </summary>
    /// <seealso cref="WriteServiceBase<TModel, TRequestDto>" />
    /// <seealso cref="ICrudService<TRequestDto, TDto, TKey>" />
    public class CrudServiceBase<TModel, TRequestDto, TDto, TKey> : WriteServiceBase<TModel, TRequestDto>, ICrudService<TRequestDto, TDto, TKey>
        where TModel : class, IEntity, IEntityBase<TKey>, new()
        where TDto : class, new()
    {
        /// <summary>
        /// The datetime provider service
        /// </summary>
        protected readonly IDatetimeProvider DatetimeProvider;

        /// <summary>
        /// The repository
        /// </summary>
        protected readonly IAsyncRelationalRepository<IMainUnitOfWork, TModel, TKey> Repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrudServiceBase{TModel, TRequestDto, TDto, TKey}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="datetimeProvider">The date time provider service</param>
        /// <param name="mapper"></param>
        /// <param name="validatorFactory">The validator factory.</param>
        protected CrudServiceBase(
            IMainUnitOfWork unitOfWork,
            IDatetimeProvider datetimeProvider,
            IMapper mapper, IValidatorFactory validatorFactory) : base(mapper, validatorFactory)
        {
            UnitOfWork = unitOfWork;
            this.DatetimeProvider = datetimeProvider;
            this.Repository = unitOfWork.GetAsyncRelationalRepository<TModel, TKey>();
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        public IMainUnitOfWork UnitOfWork { get; }

        /// <inheritdoc />
        public virtual async Task<TKey> CreateAsync(Guid userId, TRequestDto requestDto)
        {
            await ValidateAsync(requestDto);

            await AfterValidationOnCreateAsync(requestDto);

            var model = await AdaptRequestDtoAsync(requestDto);

            if (model is AuditMetadata auditModel)
            {
                var currentDateTime = DatetimeProvider.GetUtcNow();
                auditModel.CreatedById = userId;
                auditModel.CreatedOn = currentDateTime;
            }

            await BeforeCreateAsync(requestDto, model);

            try
            {
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

            if (model is IEntityBase<TKey> entityBase)
            {
                return entityBase.Id;
            }

            return default;
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(TKey id, Guid userId, params string[] loadedProperties)
        {
            var model = await GetModelAsync(id, GetPropertiesToLoad(loadedProperties));
            if (model == null)
            {
                throw new EntityNotFoundException<TKey>(id);
            }

            await BeforeDeleteAsync(model);

            if (model is HistoryMetadata historyMetadata)
            {
                historyMetadata.EndedOn = DatetimeProvider.GetUtcNow();
                historyMetadata.EndedById = userId;

                await Repository.ModifyAsync(model);
            }
            else
            {
                await Repository.RemoveAsync(model);
            }

            await Repository.UnitOfWork.CommitAsync();
        }

        /// <inheritdoc />
        public virtual async Task<TDto> GetAsync(TKey id, params string[] loadedProperties)
        {
            var model = await GetModelAsync(id, GetPropertiesToLoad(loadedProperties));

            if (model == null)
            {
                throw new EntityNotFoundException<TKey>(id, typeof(TModel));
            }

            await AfterGetAsync(model);

            var dto = await AdaptModelAsync(model);

            return dto;
        }

        /// <inheritdoc />
        public virtual async Task<IPagedEnumerable<TDto>> GetAsync(PagedListRequest dto)
        {
            if (dto.PageIndex < 1 || dto.PageSize < 1)
            {
                throw new PageOutOfRangeException();
            }
            var specification = GetSpecificationFromFilter(dto);
            var items = await Repository.GetPagedAsync(specification, dto.PageIndex, dto.PageSize, dto.OrderBy,
                GetPropertiesToLoad(dto.LoadedProperties));
            var count = await Repository.CountAsync(specification);
            var list = await AdaptModelAsync(items);
            return new PagedList<TDto>(list, count)
            {
                PageIndex = dto.PageIndex,
                PageSize = dto.PageSize
            };
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TDto>> GetAsync(params string[] loadedProperties)
        {
            var items = await Repository.AllMatchingAsync(new TrueSpecification<TModel>(),
                GetPropertiesToLoad(loadedProperties));
            return await AdaptModelAsync(items);
        }

        /// <inheritdoc />
        public virtual async Task UpdateAsync(TKey id, Guid userId, TRequestDto requestDto,
            params string[] loadedProperties)
        {
            await ValidateAsync(requestDto);
            await AfterValidationOnUpdateAsync(requestDto);

            var dbModel = await GetModelAsync(id, GetPropertiesToLoad(loadedProperties));

            if (dbModel == null)
            {
                throw new EntityNotFoundException<TKey>(id);
            }

            await BeforeUpdateAsync(dbModel, requestDto);

            dbModel = await AdaptRequestDtoAsync(requestDto, dbModel);

            if (dbModel is IEntityBase<TKey> entityBase)
            {
                entityBase.Id = id;
            }

            if (dbModel is AuditMetadata auditModel)
            {
                var currentDateTime = DatetimeProvider.GetUtcNow();

                auditModel.LastUpdatedById = userId;
                auditModel.LastUpdatedOn = currentDateTime;
            }

            try
            {
                await Repository.ModifyAsync(dbModel);
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

        /// <summary>
        /// Adapts a Model to DTO
        /// </summary>
        /// <param name="model">The model to adapt</param>
        protected virtual Task<TDto> AdaptModelAsync(TModel model)
        {
            return Task.FromResult(Mapper.Map<TDto>(model));
        }

        /// <summary>
        /// Adapts a list of Models to DTOs
        /// </summary>
        /// <param name="models">The list of models to adapt</param>
        protected virtual async Task<IEnumerable<TDto>> AdaptModelAsync(IEnumerable<TModel> models)
        {
            var result = new List<TDto>();
            foreach (var item in models)
            {
                result.Add(await AdaptModelAsync(item));
            }

            return result;
        }

        /// <summary>
        /// Allows the inherited class to inject code after the model was get
        /// </summary>
        protected virtual Task AfterGetAsync(TModel model)
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Gets the specification from filter.
        /// </summary>
        /// <returns></returns>
        protected virtual ISpecification<TModel> GetSpecificationFromFilter(PagedListRequest dto)
        {
            if (dto.FilterBy != null && dto.FilterBy.Any())
            {
                return new EntityFilterSpecification<TModel>(dto.FilterBy);
            }
            return new TrueSpecification<TModel>();
        }

        private async Task<TModel> GetModelAsync(TKey id, params string[] loadedProperties)
        {
            TModel model;
            if (loadedProperties.Length > 0)
            {
                model = await Repository.GetSingleAsync(x => x.Id.Equals(id), loadedProperties);
            }
            else
            {
                model = await Repository.GetAsync(id, loadedProperties);
            }

            return model;
        }
    }
}