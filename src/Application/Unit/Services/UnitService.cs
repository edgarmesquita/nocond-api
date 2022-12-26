using System;
using System.Linq;
using System.Threading.Tasks;
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
    public class UnitService : CrudServiceBase<UnitData, UnitRequest, Models.Unit, Guid, Guid>, IUnitService
    {
        public UnitService(IMainUnitOfWork unitOfWork, IDatetimeProvider datetimeProvider, IMapper mapper, IValidatorFactory validatorFactory)
            : base(unitOfWork, datetimeProvider, mapper, validatorFactory) { }
        
        public async Task CreateRangeAsync(Guid referenceId, Guid userId, UnitRangeRequest[] request)
        {
            foreach (var unitRangeRequest in request)
            {
                unitRangeRequest.SetReferenceId(referenceId);

                var validator = ValidatorFactory.GetValidator<UnitRangeRequest>();

                if (validator != null)
                {
                    var result = await validator.ValidateAsync(unitRangeRequest);
                    if (!result.IsValid)
                    {
                        throw new ValidationException(result.Errors);
                    }
                }

                var currentDateTime = DatetimeProvider.GetUtcNow();
                var range = Enumerable.Range(unitRangeRequest.CodeStart, unitRangeRequest.CodeEnd - unitRangeRequest.CodeStart + 1);
                foreach (var code in range)
                {
                    var model = Mapper.Map<UnitData>(unitRangeRequest);
                    model.Code = code.ToString();
                    model.CreatedById = userId;
                    model.CreatedOn = currentDateTime;

                    await Repository.AddAsync(model);
                }
            }

            await Repository.UnitOfWork.CommitAsync();
        }
    }
}