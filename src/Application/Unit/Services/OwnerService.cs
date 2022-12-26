using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using eQuantic.Core.Collections;
using eQuantic.Core.Linq.Filter;
using FluentValidation;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Models;
using NoCond.Application.Base.Providers.Interfaces;
using NoCond.Application.Base.Services;
using NoCond.Application.Unit.Data;
using NoCond.Application.Unit.Models;
using NoCond.Application.Unit.Services.Interfaces;

namespace NoCond.Application.Unit.Services
{
    public class OwnerService : CrudServiceBase<OwnerData, OwnerRequest, Owner, Guid>, IOwnerService
    {
        public OwnerService(IMainUnitOfWork unitOfWork, IDatetimeProvider datetimeProvider, IMapper mapper, IValidatorFactory validatorFactory)
            : base(unitOfWork, datetimeProvider, mapper, validatorFactory) { }

        public async Task<Owner> GetAsync(Guid personId, Guid unitId)
        {
            var model = await Repository.GetSingleAsync(
                x => x.PersonId == personId && x.UnitId == unitId && x.EndedOn == null, GetPropertiesToLoad());
            
            var dto = await AdaptModelAsync(model);

            return dto;
        }

        public Task<IPagedEnumerable<Owner>> GetAsync(Guid personId, PagedListRequest request)
        {
            var filters = new List<IFiltering>(request.FilterBy ?? new IFiltering[]{ })
            {
                new Filtering<OwnerData>(o => o.PersonId, personId.ToString())
            };
            request.FilterBy = filters.ToArray();
            
            return GetAsync(request);
        }
        
        protected override string[] GetPropertiesToLoad(params string[] loadedProperties)
        {
            return new string[]
            {
                nameof(OwnerData.Type),
                nameof(OwnerData.Unit),
                $"{nameof(OwnerData.Unit)}.{nameof(UnitData.Type)}",
                $"{nameof(OwnerData.Unit)}.{nameof(UnitData.UnitGroup)}",
                nameof(OwnerData.Person)
            };
        }
    }
}
