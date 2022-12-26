using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eQuantic.Core.Linq.Sorter;
using FluentValidation;
using NoCond.Application.Base.Exceptions;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Providers.Interfaces;
using NoCond.Application.Base.Services;
using NoCond.Application.Email.Models;
using NoCond.Application.Email.Services;
using NoCond.Application.Email.Services.Interfaces;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Meeting.Models;
using NoCond.Application.Meeting.Services.Interfaces;
using NoCond.Application.Settings.Data;
using NoCond.Application.Unit.Data;

namespace NoCond.Application.Meeting.Services
{
    /// <summary>
    /// Meeting service.
    /// </summary>
    /// <seealso cref="Meeting" />
    /// <seealso cref="IMeetingService" />
    public class MeetingService : CrudServiceBase<MeetingData, MeetingRequest, Meeting.Models.Meeting, Guid, Guid>, IMeetingService
    {
        private readonly IEmailSenderService _emailSenderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeetingService"/> class.
        /// </summary>
        /// <param name="emailSenderService"></param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="datetimeProvider">The datetime provider.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="validatorFactory">The validator factory.</param>
        public MeetingService(
            IEmailSenderService emailSenderService,
            IMainUnitOfWork unitOfWork,
            IDatetimeProvider datetimeProvider,
            IMapper mapper,
            IValidatorFactory validatorFactory) : base(unitOfWork, datetimeProvider, mapper, validatorFactory)
        {
            _emailSenderService = emailSenderService;
        }

        protected override string[] GetPropertiesToLoad(params string[] loadedProperties)
        {
            return new string[]
            {
                nameof(MeetingData.Type),
                nameof(MeetingData.UnitGroup)
            };
        }

        /// <summary>
        /// Sends invite async.
        /// </summary>
        /// <param name="id">The id.</param>
        public async Task SendInviteAsync(Guid id)
        {
            var meeting = await Repository.GetAsync(id, new string[] { });

            if (meeting == null)
            {
                throw new EntityNotFoundException<Guid>(id, typeof(Meeting.Models.Meeting));
            }
            var meetingSettings = await GetMeetingSettings();

            var ownerRepository = UnitOfWork.GetAsyncRelationalRepository<OwnerData, Guid>();
            var owners = (await ownerRepository
                .GetFilteredAsync(o =>
                    o.Unit.WithMeetings.Any(m => m.MeetingId == id) &&
                    o.EndedOn == null, new[]
                    {
                        nameof(OwnerData.Person),
                        nameof(OwnerData.Unit),
                        $"{nameof(OwnerData.Unit)}.{nameof(UnitData.Type)}"
                    })).ToList();

            if (!owners.Any())
            {
                throw new NoDataFoundException();
            }

            await _emailSenderService.SendListAsync(owners.Select(o => new EmailRequest
            {
                Subject = meeting.Name,
                ToAddresses = new[] { new EmailAddress(o.Person.Name, o.Person.Email) },
                TemplateCode = meetingSettings.CreationEmailTemplate.Code,
                TemplateParameters = { { nameof(o.Person.Name), o.Person.Name },
                        { nameof(o.Person.Email), o.Person.Email },
                        { nameof(o.Unit.Type), o.Unit.Type.Name },
                        { nameof(o.Unit.Block), o.Unit.Block },
                        { nameof(o.Unit.BlockDescription), o.Unit.BlockDescription },
                        { nameof(o.Unit.Floor), o.Unit.Floor.ToString() },
                        { nameof(o.Unit.FloorType), o.Unit.FloorType.ToString() },
                        { nameof(o.Unit.Code), o.Unit.Code },
                        { nameof(o.Unit.CodePrefix), o.Unit.CodePrefix },
                        { nameof(o.Unit.CodeSuffix), o.Unit.CodeSuffix },
                        { nameof(o.Unit.Side), o.Unit.Side }
                    }
            }).ToArray());
        }

        private async Task<MeetingSettingsData> GetMeetingSettings()
        {
            var meetingSettingsRepository = UnitOfWork.GetAsyncRelationalRepository<MeetingSettingsData, Guid>();
            return await meetingSettingsRepository.GetFirstAsync(o =>
                o.EndedOn == null, new[]
                {
                    new Sorting<MeetingSettingsData>(c => c.CreatedOn, SortDirection.Descending),
                },
                new[]
                {
                    nameof(MeetingSettingsData.CreationEmailTemplate)
                });
        }
    }
}