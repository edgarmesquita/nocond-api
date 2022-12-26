using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Meeting.Data
{
    public class MeetingTypeData : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<MeetingData> Meetings { get; set; } = new HashSet<MeetingData>();
    }
}
