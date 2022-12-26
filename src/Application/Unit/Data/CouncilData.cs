using System;
using eQuantic.Core.Data.Repository;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Unit.Data
{
    public class CouncilData : HistoryMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public Guid UnitGroupId { get; set; }

        public UnitGroupData UnitGroup { get; set; }
    }
}