using Lamar;
using NoCond.Persistence.Registry;

namespace NoCond.Persistence.Extensions
{
    public static class ServiceRegistryExtensions
    {
        /// <summary>
        /// Includes the persistence service registry.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static ServiceRegistry IncludePersistenceServiceRegistry(this ServiceRegistry services)
        {
            services.IncludeRegistry<PersistenceServiceRegistry>();
            return services;
        }
    }
}