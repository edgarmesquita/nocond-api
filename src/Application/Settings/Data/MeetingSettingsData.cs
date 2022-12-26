using System;
using NoCond.Application.Base.Models;
using NoCond.Application.Email.Data;

namespace NoCond.Application.Settings.Data
{
    public class MeetingSettingsData : HistoryMetadata, IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public Guid CreationEmailTemplateId { get; set; }
        public EmailTemplateData CreationEmailTemplate { get; set; }

        public Guid BeforeNotificationEmailTemplateId { get; set; }
        public EmailTemplateData BeforeNotificationEmailTemplate { get; set; }
    }
}