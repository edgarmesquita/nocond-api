using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Meeting.Data
{
    public class DocumentData : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public string Path { get; set; }

        public ICollection<MeetingDocumentData> WithMeetings { get; set; } = new HashSet<MeetingDocumentData>();
    }
}
