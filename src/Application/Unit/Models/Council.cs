using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Unit.Models
{
    public class Council: IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UnitGroup UnitGroup { get; set; }
    }
}