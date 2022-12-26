using System;

namespace NoCond.Application.Person.Data
{
    public class PersonAdressesData
    {
        public Guid PersonId { get; set; }

        public PersonData Person { get; set; }

        public Guid AddressId { get; set; }

        public AddressData Address { get; set; }
    }
}
