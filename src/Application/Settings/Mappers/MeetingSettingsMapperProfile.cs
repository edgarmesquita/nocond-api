using AutoMapper;
using NoCond.Application.Settings.Data;
using NoCond.Application.Settings.Models;

namespace NoCond.Application.Settings.Mappers
{
    public class MeetingSettingsMapperProfile: Profile
    {
        public MeetingSettingsMapperProfile()
        {
            CreateMap<MeetingSettings, MeetingSettingsData>()
                .ReverseMap();
            
            CreateMap<MeetingSettingsRequest, MeetingSettingsData>();
        }
    }
}