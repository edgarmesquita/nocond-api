using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Person.Models
{
    public class PersonUnitRequest : IReferencedRequestBase<Guid>
    {
        private Guid personId;
        public Guid UnitId{ get; set; }
        public Guid OwnerTypeId { get; set; }
        public void SetReferenceId(Guid referenceKey)
        {
            personId = referenceKey;
        }

        public Guid GetReferenceId()
        {
            return personId;
        }
    }
}