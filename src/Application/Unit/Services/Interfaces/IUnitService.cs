using System;
using System.Threading.Tasks;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Services.Interfaces
{
    public interface IUnitService: ICrudService<UnitRequest, Unit.Models.Unit, Guid, Guid>
    {
        Task CreateRangeAsync(Guid referenceId, Guid userId, UnitRangeRequest[] request);
    }
}