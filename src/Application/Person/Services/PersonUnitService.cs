using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eQuantic.Core.Collections;
using NoCond.Application.Base.Models;
using NoCond.Application.Person.Models;
using NoCond.Application.Person.Services.Interfaces;
using NoCond.Application.Unit.Models;
using NoCond.Application.Unit.Services.Interfaces;

namespace NoCond.Application.Person.Services
{
    /// <summary>
    /// Person Unit Service
    /// </summary>
    public class PersonUnitService : IPersonUnitService
    {
        private readonly IOwnerService ownerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerService"></param>
        public PersonUnitService(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }
        
        public Task<Guid> CreateAsync(Guid referenceId, Guid userId, PersonUnitRequest requestDto)
        {
            return ownerService.CreateAsync(userId, new OwnerRequest
            {
                PersonId = referenceId,
                UnitId = requestDto.UnitId,
                OwnerTypeId = requestDto.OwnerTypeId
            });
        }

        public Task DeleteAsync(Guid referenceId, Guid id, Guid userId, params string[] loadedProperties)
        {
            return ownerService.DeleteAsync(id, userId, loadedProperties);
        }

        public async Task<Unit.Models.Unit> GetAsync(Guid referenceId, Guid id, params string[] loadedProperties)
        {
            var owner = await ownerService.GetAsync(referenceId, id);
            return owner.Unit;
        }

        public async Task<IPagedEnumerable<Unit.Models.Unit>> GetAsync(Guid referenceId, ReferencedPagedListRequest<Guid> request)
        {
            var list = await ownerService.GetAsync(referenceId, request);
            return new PagedList<Unit.Models.Unit>(list.Select(o => o.Unit), list.TotalCount)
            {
                PageIndex = list.PageIndex,
                PageSize = list.PageSize
            };
        }

        public async Task<IEnumerable<Unit.Models.Unit>> GetAsync(Guid referenceId, params string[] loadedProperties)
        {
            return await GetAsync(referenceId, new ReferencedPagedListRequest<Guid>
            {
                 PageIndex = 1,
                 PageSize = 1000
            });
        }

        public Task UpdateAsync(Guid referenceId, Guid id, Guid userId, PersonUnitRequest requestDto,
            params string[] loadedProperties)
        {
            return ownerService.UpdateAsync(id, userId, new OwnerRequest
            {
                PersonId = referenceId,
                UnitId = requestDto.UnitId,
                OwnerTypeId = requestDto.OwnerTypeId
            });
        }
    }
}