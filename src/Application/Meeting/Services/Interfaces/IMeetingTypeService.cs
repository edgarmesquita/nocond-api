using System;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Services.Interfaces
{
    /// <summary>
    /// MeetingType service.
    /// </summary>
    /// <seealso cref="ICrudService<MeetingTypeRequest, Meeting.Models.MeetingType, Guid>" />
    public interface IMeetingTypeService : ICrudService<MeetingTypeRequest, MeetingType, Guid>
    {

    }
}