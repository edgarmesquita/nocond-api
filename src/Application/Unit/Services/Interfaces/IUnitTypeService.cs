using System;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Services.Interfaces
{
    public interface IUnitTypeService : ICrudService<UnitTypeRequest, UnitType, Guid>
    {

    }
}