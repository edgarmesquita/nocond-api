namespace NoCond.Application.Person.Models
{
    public class PersonRequest : AddressRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string Nickname { get; set; }

        public string TaxNumber { get; set; }

        public string IdNumber { get; set; }
        
        public PersonType Type { get; set; }
    }
}