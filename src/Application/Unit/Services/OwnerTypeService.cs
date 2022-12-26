using System;
using AutoMapper;
using FluentValidation;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Providers.Interfaces;
using NoCond.Application.Base.Services;
using NoCond.Application.Unit.Data;
using NoCond.Application.Unit.Models;
using NoCond.Application.Unit.Services.Interfaces;

namespace NoCond.Application.Unit.Services
{
    public class OwnerTypeService : CrudServiceBase<OwnerTypeData, OwnerTypeRequest, OwnerType, Guid>, IOwnerTypeService
    {
        public OwnerTypeService(IMainUnitOfWork unitOfWork, IDatetimeProvider datetimeProvider, IMapper mapper, IValidatorFactory validatorFactory)
            : base(unitOfWork, datetimeProvider, mapper, validatorFactory) { }
    }
}
