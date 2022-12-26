using AutoMapper;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Mappers
{
    public class VotingTopicOptionMapperProfile: Profile
    {
        public VotingTopicOptionMapperProfile()
        {
            CreateMap<VotingTopicOption, VotingTopicOptionData>()
                .ReverseMap();
            
            CreateMap<VotingTopicOptionRequest, VotingTopicOptionData>();
        }
    }
}