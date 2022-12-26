using System.Diagnostics.CodeAnalysis;
using Lamar;
using NoCond.Api.Registry;

namespace NoCond.Api.Extensions
{
    /// <summary>
    /// Service Registry Extensions
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ServiceRegistryExtensions
    {
        /// <summary>
        /// Includes the API service registry.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static ServiceRegistry IncludeApiServiceRegistry (this ServiceRegistry services)
        {
            services.IncludeRegistry<ApiServiceRegistry> ();
            return services;
        }
    }
}