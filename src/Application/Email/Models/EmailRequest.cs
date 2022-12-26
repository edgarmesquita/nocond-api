using System.Collections.Generic;

namespace NoCond.Application.Email.Models
{
    public class EmailRequest
    {
        public EmailAddress FromAddress { get; set; }
        public EmailAddress[] ToAddresses { get; set; }
        public EmailAddress[] CcAddresses { get; set; }
        public EmailAddress[] BccAddresses { get; set; }
        public string Subject { get; set; }

        public string TemplateCode { get; set; }
        public Dictionary<string, string> TemplateParameters { get; } = new Dictionary<string, string>();
    }
}