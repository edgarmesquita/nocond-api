using Lamar;
using NoCond.Application.Email.Services;
using NoCond.Application.Email.Services.Interfaces;
using NoCond.Infrastructure.Services;

namespace NoCond.Infrastructure.Registry
{
    internal class InfrastructureServiceRegistry : ServiceRegistry
    {
        public InfrastructureServiceRegistry()
        {
            For<IEmailSenderService>().Use<EmailSenderService>();
        }
    }
}