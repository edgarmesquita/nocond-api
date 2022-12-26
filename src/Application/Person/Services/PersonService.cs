using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Providers.Interfaces;
using NoCond.Application.Base.Services;
using NoCond.Application.Person.Data;
using NoCond.Application.Person.Models;
using NoCond.Application.Person.Services.Interfaces;

namespace NoCond.Application.Person.Services
{
    public class PersonService : CrudServiceBase<PersonData, PersonRequest, Models.Person, Guid>, IPersonService
    {
        public PersonService(IMainUnitOfWork unitOfWork, IDatetimeProvider datetimeProvider, IMapper mapper, IValidatorFactory validatorFactory)
            : base(unitOfWork, datetimeProvider, mapper, validatorFactory) { }

        protected override async Task<Models.Person> AdaptModelAsync(PersonData model)
        {
            var person = await base.AdaptModelAsync(model);
            person.Address = model.WithAddresses.Select(o => Mapper.Map<Address>(o.Address)).FirstOrDefault();

            return person;
        }

        protected override async Task BeforeCreateAsync(PersonRequest personRequest, PersonData person)
        {
            var addressRepository = UnitOfWork.GetAsyncRepository<AddressData, Guid>();

            var address = Mapper.Map<AddressRequest, AddressData>(personRequest);
            address.CreatedOn = DatetimeProvider.GetUtcNow();

            await addressRepository.AddAsync(address);
            await addressRepository.UnitOfWork.CommitAsync();

            person.WithAddresses.Add(new PersonAdressesData { AddressId = address.Id });
        }

        protected override string[] GetPropertiesToLoad(params string[] loadedProperties)
        {
            return new[]
            {
                nameof(PersonData.WithAddresses),
                $"{nameof(PersonData.WithAddresses)}.{nameof(PersonAdressesData.Address)}"
            };
        }
    }
}
