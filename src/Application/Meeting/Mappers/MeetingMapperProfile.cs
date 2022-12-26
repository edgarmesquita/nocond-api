using AutoMapper;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Mappers
{
    public class MeetingMapperProfile : Profile
    {
        public MeetingMapperProfile()
        {
            CreateMap<Models.Meeting, MeetingData>()
                .ReverseMap();
            
            CreateMap<MeetingRequest, MeetingData>()
                .ForMember(
                    dest => dest.UnitGroupId,
                    opt => opt.MapFrom(src => src.GetReferenceId()));
        }
    }
}