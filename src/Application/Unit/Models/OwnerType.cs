using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Unit.Models
{
    public class OwnerType : IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}