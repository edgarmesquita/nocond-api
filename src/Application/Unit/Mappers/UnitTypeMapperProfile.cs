using AutoMapper;
using NoCond.Application.Unit.Data;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Mappers
{
    public class UnitTypeMapperProfile: Profile
    {
        public UnitTypeMapperProfile()
        {
            CreateMap<UnitType, UnitTypeData>()
                .ReverseMap();
            
            CreateMap<UnitTypeRequest, UnitTypeData>();
        }
    }
}