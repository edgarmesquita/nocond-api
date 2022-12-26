using System;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Email.Models;

namespace NoCond.Application.Email.Services.Interfaces
{
    public interface IEmailTemplateService : ICrudService<EmailTemplateRequest, EmailTemplate, Guid>
    {
        
    }
}