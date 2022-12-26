using System;
using eQuantic.Core.Data.Repository;

namespace NoCond.Application.Meeting.Data
{
    public class MeetingDocumentData : IEntity
    {
        public Guid MeetingId { get; set; }

        public MeetingData Meeting { get; set; }

        public Guid DocumentId { get; set; }

        public DocumentData Document { get; set; }
    }
}
