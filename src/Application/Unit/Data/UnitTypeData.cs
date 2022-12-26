using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Unit.Data
{
    public class UnitTypeData : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<UnitData> Units { get; set; } = new HashSet<UnitData>();
    }
}