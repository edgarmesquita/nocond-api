using System;
using NoCond.Application.Base.Models;
using NoCond.Application.Meeting.Models;
using NoCond.Application.Person.Data;

namespace NoCond.Application.Meeting.Data
{
    public class VotingTopicOptionData : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public Guid VotingTopicId { get; set; }

        public VotingTopicData VotingTopic { get; set; }

        public Guid PersonId { get; set; }
        
        public PersonData Person { get; set; }

        public VotingTopicOptionType TypeCode { get; set; }

        public string Label { get; set; }

        public bool Editable { get; set; }

        public bool IsFillableOption { get; set; }
    }
}
