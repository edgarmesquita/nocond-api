using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;
using NoCond.Application.Meeting.Models;
using NoCond.Application.Unit.Data;

namespace NoCond.Application.Meeting.Data
{
    public class MeetingData : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        
        public Guid UnitGroupId { get; set; }
        
        public UnitGroupData UnitGroup { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid MeetingTypeId { get; set; }

        public MeetingTypeData Type { get; set; }

        public ICollection<MeetingUnitData> WithUnits { get; set; } = new HashSet<MeetingUnitData>();

        public ICollection<MeetingDocumentData> WithDocuments { get; set; } = new HashSet<MeetingDocumentData>();

        public ICollection<VotingSessionData> VotingSessions { get; set; } = new HashSet<VotingSessionData>();

        public DateTime StartsOn { get; set; }

        public DateTime EndsOn { get; set; }

        public MeetingStatus StatusCode { get; set; }
    }
}