using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Person.Models
{
    public class Address : AuditMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }
        
        public string Number { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }
}