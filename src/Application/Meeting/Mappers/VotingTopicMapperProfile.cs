using AutoMapper;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Mappers
{
    public class VotingTopicMapperProfile: Profile
    {
        public VotingTopicMapperProfile()
        {
            CreateMap<VotingTopic, VotingTopicData>()
                .ReverseMap();
            
            CreateMap<VotingTopicRequest, VotingTopicData>();
        }
    }
}