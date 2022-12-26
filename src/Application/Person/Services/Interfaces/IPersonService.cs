using System;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Person.Models;

namespace NoCond.Application.Person.Services.Interfaces
{
    public interface IPersonService: ICrudService<PersonRequest, Models.Person, Guid>
    {
        
    }
}