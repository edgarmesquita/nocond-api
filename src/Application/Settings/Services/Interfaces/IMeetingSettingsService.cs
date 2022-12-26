using System.Threading.Tasks;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Settings.Data;
using NoCond.Application.Settings.Models;

namespace NoCond.Application.Settings.Services.Interfaces
{
    public interface IMeetingSettingsService : IOnlyOneService<MeetingSettingsRequest, MeetingSettings>
    {
        
    }
}