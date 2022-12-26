using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Meeting.Models
{
    public class MeetingType : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}