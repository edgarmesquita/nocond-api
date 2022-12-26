using System;

namespace NoCond.Application.Base.Models
{
    public abstract class HistoryMetadata : AuditMetadata
    {
        public DateTime? EndedOn { get; set; }
        public Guid? EndedById { get; set; }
    }
}