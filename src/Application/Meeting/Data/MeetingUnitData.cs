using System;
using eQuantic.Core.Data.Repository;
using NoCond.Application.Unit.Data;

namespace NoCond.Application.Meeting.Data
{
    public class MeetingUnitData : IEntity
    {
        public Guid MeetingId { get; set; }

        public MeetingData Meeting { get; set; }

        public Guid UnitId { get; set; }

        public UnitData Unit { get; set; }
    }
}
