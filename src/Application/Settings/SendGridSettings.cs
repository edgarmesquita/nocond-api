namespace NoCond.Application.Settings
{
    /// <summary>
    /// SendGrid Settings
    /// </summary>
    public class SendGridSettings
    {
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string ApiKey { get; set; }
    }
}