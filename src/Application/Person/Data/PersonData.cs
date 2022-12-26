using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Person.Models;
using NoCond.Application.Unit.Data;

namespace NoCond.Application.Person.Data
{
    public class PersonData : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public ICollection<PersonAdressesData> WithAddresses { get; set; } = new HashSet<PersonAdressesData>();

        public ICollection<VotingTopicCandidateData> WithCandidates { get; set; } = new HashSet<VotingTopicCandidateData>();
        public ICollection<VotingTopicOptionData> VotingTopicOptions { get; set; } = new HashSet<VotingTopicOptionData>();
        
        public ICollection<OwnerData> Owners { get; set; } = new HashSet<OwnerData>();

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string Nickname { get; set; }

        public string TaxNumber { get; set; }

        public string IdNumber { get; set; }
        
        public PersonType Type { get; set; }
    }
}
