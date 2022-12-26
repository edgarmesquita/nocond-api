using System;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Person.Models;

namespace NoCond.Application.Person.Services.Interfaces
{
    public interface IPersonUnitService: ICrudService<PersonUnitRequest, Unit.Models.Unit, Guid, Guid>
    {
        
    }
}