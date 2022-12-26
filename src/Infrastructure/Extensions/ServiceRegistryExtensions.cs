using Lamar;
using NoCond.Infrastructure.Registry;

namespace NoCond.Infrastructure.Extensions
{
    public static class ServiceRegistryExtensions
    {
        /// <summary>
        /// Includes the infrastructure service registry.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static ServiceRegistry IncludeInfrastructureServiceRegistry(this ServiceRegistry services)
        {
            services.IncludeRegistry<InfrastructureServiceRegistry>();
            return services;
        }
    }
}