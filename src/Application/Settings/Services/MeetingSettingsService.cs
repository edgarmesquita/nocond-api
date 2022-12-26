using System;
using AutoMapper;
using FluentValidation;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Providers.Interfaces;
using NoCond.Application.Base.Services;
using NoCond.Application.Settings.Data;
using NoCond.Application.Settings.Models;
using NoCond.Application.Settings.Services.Interfaces;

namespace NoCond.Application.Settings.Services
{
    public class MeetingSettingsService :  OnlyOneServiceBase<MeetingSettingsData, MeetingSettingsRequest, MeetingSettings, Guid>, IMeetingSettingsService
    {
        public MeetingSettingsService(IMainUnitOfWork unitOfWork, IDatetimeProvider datetimeProvider, IMapper mapper,
            IValidatorFactory validatorFactory) : base(unitOfWork, datetimeProvider, mapper, validatorFactory)
        {
        }
    }
}