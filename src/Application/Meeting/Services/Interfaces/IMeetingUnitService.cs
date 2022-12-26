using System;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Services.Interfaces
{
    public interface IMeetingUnitService: ICrudService<MeetingUnitRequest, MeetingUnit, Guid>
    {
        
    }
}