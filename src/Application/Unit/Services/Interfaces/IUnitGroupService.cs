using System;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Services.Interfaces
{
    public interface IUnitGroupService : ICrudService<UnitGroupRequest, UnitGroup, Guid>
    {

    }
}