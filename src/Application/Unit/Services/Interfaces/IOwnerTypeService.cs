using System;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Meeting.Models;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Services.Interfaces
{
    public interface IOwnerTypeService: ICrudService<OwnerTypeRequest, OwnerType, Guid>
    {
        
    }
}