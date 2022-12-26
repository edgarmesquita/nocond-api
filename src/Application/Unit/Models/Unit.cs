using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Unit.Models
{
    public class Unit : IEntityBase<Guid>
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
        
        public UnitType Type { get; set; }
        public UnitGroup UnitGroup { get; set; }
    }
}