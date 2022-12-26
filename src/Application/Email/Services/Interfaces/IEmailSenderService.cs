using System.Threading.Tasks;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Email.Models;

namespace NoCond.Application.Email.Services.Interfaces
{
    public interface IEmailSenderService : IApplicationService
    {
        Task SendAsync(EmailRequest request);
        Task SendListAsync(EmailRequest[] request);
    }
}