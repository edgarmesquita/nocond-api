using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Meeting.Models
{
    public class MeetingRequest : IReferencedRequestBase<Guid>
    {
        private Guid unitGroupId;
        
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid MeetingTypeId { get; set; }

        public DateTime StartsOn { get; set; }

        public DateTime EndsOn { get; set; }

        public MeetingStatus StatusCode { get; set; }
        
        public void SetReferenceId(Guid referenceKey)
        {
            unitGroupId = referenceKey;
        }

        public Guid GetReferenceId()
        {
            return unitGroupId;
        }
    }
}