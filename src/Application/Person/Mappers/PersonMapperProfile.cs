using AutoMapper;
using NoCond.Application.Person.Data;
using NoCond.Application.Person.Models;

namespace NoCond.Application.Person.Mappers
{
    public class PersonMapperProfile: Profile
    {
        public PersonMapperProfile()
        {
            CreateMap<Models.Person, PersonData>()
                .ReverseMap();
            
            CreateMap<PersonRequest, PersonData>();
        }
    }
}