using AutoMapper;
using NoCond.Application.Unit.Data;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Mappers
{
    public class OwnerTypeMapperProfile: Profile
    {
        public OwnerTypeMapperProfile()
        {
            CreateMap<OwnerType, OwnerTypeData>()
                .ReverseMap();
            
            CreateMap<OwnerTypeRequest, OwnerTypeData>();
        }
    }
}