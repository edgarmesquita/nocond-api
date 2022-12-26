using System;
using AutoMapper;
using FluentValidation;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Providers.Interfaces;
using NoCond.Application.Base.Services;
using NoCond.Application.Email.Data;
using NoCond.Application.Email.Models;
using NoCond.Application.Email.Services.Interfaces;

namespace NoCond.Application.Email.Services
{
    public class EmailTemplateService : CrudServiceBase<EmailTemplateData, EmailTemplateRequest, EmailTemplate, Guid>, IEmailTemplateService
    {
        public EmailTemplateService(IMainUnitOfWork unitOfWork, IDatetimeProvider datetimeProvider, IMapper mapper, IValidatorFactory validatorFactory) : base(unitOfWork, datetimeProvider, mapper, validatorFactory)
        {
        }
    }
}