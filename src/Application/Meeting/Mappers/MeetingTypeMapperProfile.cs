using AutoMapper;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Mappers
{
    public class MeetingTypeMapperProfile : Profile
    {
        public MeetingTypeMapperProfile()
        {
            CreateMap<MeetingType, MeetingTypeData>()
                .ReverseMap();

            CreateMap<MeetingTypeRequest, MeetingTypeData>();
        }
    }
}
