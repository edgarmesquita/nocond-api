using AutoMapper;
using NoCond.Application.Unit.Data;
using NoCond.Application.Unit.Models;

namespace NoCond.Application.Unit.Mappers
{
    public class UnitMapperProfile: Profile
    {
        public UnitMapperProfile()
        {
            CreateMap<Unit.Models.Unit, UnitData>()
                .ReverseMap();
            
            CreateMap<UnitRequest, UnitData>()
                .ForMember(
                    dest => dest.UnitGroupId,
                    opt => opt.MapFrom(src => src.GetReferenceId()));
            
            CreateMap<UnitRangeRequest, UnitData>()
                .ForMember(
                    dest => dest.UnitGroupId,
                    opt => opt.MapFrom(src => src.GetReferenceId()));
        }
    }
}