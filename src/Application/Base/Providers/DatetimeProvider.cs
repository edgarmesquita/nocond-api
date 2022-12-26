using System;
using NoCond.Application.Base.Providers.Interfaces;

namespace NoCond.Application.Base.Providers
{
    public class DatetimeProvider : IDatetimeProvider
    {
        public DateTime GetUtcNow() => DateTime.UtcNow;
    }
}