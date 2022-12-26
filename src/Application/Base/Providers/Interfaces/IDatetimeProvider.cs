using System;

namespace NoCond.Application.Base.Providers.Interfaces
{
    public interface IDatetimeProvider
    {
        DateTime GetUtcNow();
    }
}