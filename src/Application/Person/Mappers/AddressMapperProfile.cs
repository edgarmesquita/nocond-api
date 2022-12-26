using AutoMapper;
using NoCond.Application.Person.Data;
using NoCond.Application.Person.Models;

namespace NoCond.Application.Person.Mappers
{
    public class AddressMapperProfile: Profile
    {
        public AddressMapperProfile()
        {
            CreateMap<Address, AddressData>()
                .ReverseMap();

            CreateMap<AddressRequest, AddressData>()
                .ForMember(dest => dest.Number, 
                    opt => opt.MapFrom(src => src.AddressNumber));
        }
    }
}