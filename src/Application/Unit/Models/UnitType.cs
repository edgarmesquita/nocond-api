using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Unit.Models
{
    public class UnitType: IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public DateTime CreatedOn { get; set; }
    }
}