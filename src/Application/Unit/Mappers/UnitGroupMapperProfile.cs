using AutoMapper;
using NoCond.Application.Unit.Data;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Mappers
{
    public class UnitGroupMapperProfile: Profile
    {
        public UnitGroupMapperProfile()
        {
            CreateMap<UnitGroup, UnitGroupData>()
                .ReverseMap();
            
            CreateMap<UnitGroupRequest, UnitGroupData>();
        }
    }
}