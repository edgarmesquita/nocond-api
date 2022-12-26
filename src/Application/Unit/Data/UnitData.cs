using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Data
{
    public class UnitData : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public int Floor { get; set; }
        public FloorType FloorType { get; set; }
        public string Block { get; set; }
        public string BlockDescription { get; set; }
        public string Side { get; set; }
        public string Code { get; set; }
        public string CodePrefix { get; set; }
        public string CodeSuffix { get; set; }
        public Guid UnitTypeId { get; set; }

        public Guid UnitGroupId { get; set; }
        public UnitGroupData UnitGroup { get; set; }
        public UnitTypeData Type { get; set; }

        public ICollection<OwnerData> Owners { get; set; } = new HashSet<OwnerData>();

        public ICollection<MeetingUnitData> WithMeetings { get; set; } = new HashSet<MeetingUnitData>();
    }
}
