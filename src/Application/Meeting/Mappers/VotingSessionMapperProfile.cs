using AutoMapper;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Mappers
{
    public class VotingSessionMapperProfile: Profile
    {
        public VotingSessionMapperProfile()
        {
            CreateMap<VotingSession, VotingSessionData>()
                .ReverseMap();

            CreateMap<VotingSessionRequest, VotingSessionData>()
                .ForMember(
                    dest => dest.MeetingId, 
                    opt => 
                        opt.MapFrom(src => src.GetReferenceId()));
        }
    }
}