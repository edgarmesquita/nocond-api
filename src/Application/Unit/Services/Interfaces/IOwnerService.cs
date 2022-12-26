using System;
using System.Threading.Tasks;
using eQuantic.Core.Collections;
using NoCond.Application.Base.Models;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Services.Interfaces
{
    public interface IOwnerService: ICrudService<OwnerRequest, Owner, Guid>
    {
        Task<Owner> GetAsync(Guid personId, Guid unitId);
        Task<IPagedEnumerable<Owner>> GetAsync(Guid personId, PagedListRequest request);
    }
}