using System;
using eQuantic.Core.Data.Repository;

namespace NoCond.Application.Unit.Data
{
    public class CouncilOwnerData : IEntity
    {
        public Guid CouncilId { get; set; }
        public CouncilData Council { get; set; }
        
        public Guid OwnerId { get; set; }
        public OwnerData Owner { get; set; }
    }
}