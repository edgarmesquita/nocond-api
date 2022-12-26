using AutoMapper;
using NoCond.Application.Email.Data;
using NoCond.Application.Email.Models;

namespace NoCond.Application.Email.Mappers
{
    public class EmailTemplateMapperProfile: Profile
    {
        public EmailTemplateMapperProfile()
        {
            CreateMap<EmailTemplate, EmailTemplateData>()
                .ReverseMap();
            
            CreateMap<EmailTemplateRequest, EmailTemplateData>();
        }
    }
}