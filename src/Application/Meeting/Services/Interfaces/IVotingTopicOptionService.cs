using System;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Services.Interfaces
{
    public interface IVotingTopicOptionService: ICrudService<VotingTopicOptionRequest, VotingTopicOption, Guid>
    {
        
    }
}