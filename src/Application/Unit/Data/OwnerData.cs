using System;
using NoCond.Application.Base.Models;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Person.Data;

namespace NoCond.Application.Unit.Data
{
    public class OwnerData : HistoryMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        public PersonData Person { get; set; }

        public Guid UnitId { get; set; }

        public UnitData Unit { get; set; }

        public Guid OwnerTypeId { get; set; }

        public OwnerTypeData Type { get; set; }
    }
}
