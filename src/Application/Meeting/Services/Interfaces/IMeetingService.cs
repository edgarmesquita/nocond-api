using System;
using System.Threading.Tasks;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Services.Interfaces
{
    /// <summary>
    /// Meeting service.
    /// </summary>
    /// <seealso cref="ICrudService<MeetingRequest, Meeting.Models.Meeting, Guid>" />
    public interface IMeetingService : ICrudService<MeetingRequest, Models.Meeting, Guid, Guid>
    {
        /// <summary>
        /// Sends invite async.
        /// </summary>
        /// <param name="id">The id.</param>
        Task SendInviteAsync(Guid id);
    }
}