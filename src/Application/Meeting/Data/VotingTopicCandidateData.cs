using System;
using NoCond.Application.Base.Models;
using NoCond.Application.Person.Data;

namespace NoCond.Application.Meeting.Data
{
    public class VotingTopicCandidateData : HistoryMetadata
    {
        public Guid PersonId { get; set; }
        public PersonData Person { get; set; }
        
        public Guid VotingTopicId { get; set; }
        public VotingTopicData VotingTopic { get; set; }
    }
}