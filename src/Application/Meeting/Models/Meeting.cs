using System;
using NoCond.Application.Base.Models;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Meeting.Models
{
    public class Meeting : IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MeetingType Type { get; set; }

        public DateTime? StartsOn { get; set; }

        public DateTime? EndsOn { get; set; }

        public MeetingStatus StatusCode { get; set; }
        
        public UnitGroup UnitGroup { get; set; }
    }
}