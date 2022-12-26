using AutoMapper;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Meeting.Models;

namespace NoCond.Application.Meeting.Mappers
{
    public class DocumentMapperProfile: Profile
    {
        public DocumentMapperProfile()
        {
            CreateMap<Document, DocumentData>()
                .ReverseMap();
            
            CreateMap<DocumentRequest, DocumentData>();
        }
    }
}