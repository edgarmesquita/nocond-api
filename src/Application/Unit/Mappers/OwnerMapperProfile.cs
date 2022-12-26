using AutoMapper;
using NoCond.Application.Unit.Data;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Mappers
{
    public class OwnerMapperProfile: Profile
    {
        public OwnerMapperProfile()
        {
            CreateMap<Owner, OwnerData>()
                .ReverseMap();
            
            CreateMap<OwnerRequest, OwnerData>();
        }
    }
}