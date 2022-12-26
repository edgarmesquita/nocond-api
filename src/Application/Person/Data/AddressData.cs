using System;
using System.Collections.Generic;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Person.Data
{
    public class AddressData : HistoryMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public ICollection<PersonAdressesData> WithPersons { get; set; } = new HashSet<PersonAdressesData>();

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Number { get; set; }
        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }
}
