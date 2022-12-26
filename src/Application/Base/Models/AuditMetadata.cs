using System;

namespace NoCond.Application.Base.Models
{
    public abstract class AuditMetadata
    {
        public Guid? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}