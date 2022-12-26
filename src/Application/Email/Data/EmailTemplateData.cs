using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Email.Data
{
    public class EmailTemplateData : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public string Code { get; set; }
    }
}