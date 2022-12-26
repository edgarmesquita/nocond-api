using System;
using NoCond.Application.Base.Models;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Unit.Models
{
    public class Owner : IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public Person.Models.Person Person { get; set; }

        public Unit Unit { get; set; }

        public OwnerType Type { get; set; }
    }
}