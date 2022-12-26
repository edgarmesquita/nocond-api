using System;

namespace NoCond.Application.Unit.Models
{
    public class OwnerRequest
    {
        public Guid PersonId { get; set; }

        public Guid UnitId { get; set; }

        public Guid OwnerTypeId { get; set; }

    }
}