using NoCond.Application.Email.Models;

namespace NoCond.Application.Settings.Models
{
    public class MeetingSettings
    {
        public EmailTemplate CreationEmailTemplate { get; set; }
        public EmailTemplate BeforeNotificationEmailTemplate { get; set; }
    }
}