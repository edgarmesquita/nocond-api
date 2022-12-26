using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Meeting.Data
{
    public class VotingTopicData : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public Guid VotingSessionId { get; set; }

        public VotingSessionData VotingSession { get; set; }

        public string Text { get; set; }

        public string Introdution { get; set; }

        public int AnswerLimit { get; set; }

        public int Order { get; set; }

        public int Duration { get; set; }

        public ICollection<VotingTopicOptionData> VotingTopicOptions { get; set; } = new HashSet<VotingTopicOptionData>();
        
        public ICollection<VotingTopicCandidateData> WithCandidates { get; set; } = new HashSet<VotingTopicCandidateData>();
    }
}
