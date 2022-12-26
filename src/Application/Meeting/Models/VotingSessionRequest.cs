using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Meeting.Models
{
    public class VotingSessionRequest : IReferencedRequestBase<Guid>
    {
        private Guid meetingId;
        
        public DateTime StartsOn { get; set; }

        public DateTime EndsOn { get; set; }
        
        public void SetReferenceId(Guid referenceKey)
        {
            meetingId = referenceKey;
        }

        public Guid GetReferenceId()
        {
            return meetingId;
        }
    }
}