using System;
using AutoMapper;
using FluentValidation;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Providers.Interfaces;
using NoCond.Application.Base.Services;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Meeting.Models;
using NoCond.Application.Meeting.Services.Interfaces;

namespace NoCond.Application.Meeting.Services
{
    public class VotingTopicService : CrudServiceBase<VotingTopicData, VotingTopicRequest, VotingTopic, Guid>, IVotingTopicService
    {
        public VotingTopicService(IMainUnitOfWork unitOfWork, IDatetimeProvider datetimeProvider, IMapper mapper, IValidatorFactory validatorFactory)
            : base(unitOfWork, datetimeProvider, mapper, validatorFactory) { }
    }
}