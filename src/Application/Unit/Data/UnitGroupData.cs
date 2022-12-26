using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;
using NoCond.Application.Meeting.Data;

namespace NoCond.Application.Unit.Data
{
    public class UnitGroupData : AuditMetadata, IEntityBase<Guid>
    {
        public string Name { get; set; }

        public ICollection<UnitData> Units { get; set; } = new HashSet<UnitData>();
        public ICollection<MeetingData> Meetings { get; set; } = new HashSet<MeetingData>();
        public Guid Id { get; set; }
    }
}