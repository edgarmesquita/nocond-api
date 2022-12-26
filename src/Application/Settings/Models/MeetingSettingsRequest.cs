using System;

namespace NoCond.Application.Settings.Models
{
    public class MeetingSettingsRequest
    {
        public Guid CreationEmailTemplateId { get; set; }
        public Guid BeforeNotificationEmailTemplateId { get; set; }
    }
}