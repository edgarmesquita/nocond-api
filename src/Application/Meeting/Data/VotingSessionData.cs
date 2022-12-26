using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Data
{
    public class VotingSessionData : HistoryMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        
        public string Description { get; set; }

        public int Order { get; set; }
        
        public Guid MeetingId { get; set; }

        public MeetingData Meeting { get; set; }

        public ICollection<VotingTopicData> VotingTopics { get; set; } = new HashSet<VotingTopicData>();

        public VotingSessionStatus StatusCode { get; set; }

        public DateTime StartsOn { get; set; }

        public DateTime EndsOn { get; set; }
    }
}
