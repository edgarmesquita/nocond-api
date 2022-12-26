using System.Reflection;
using eQuantic.Core.Data.Repository;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using NoCond.Application.Base.Infrastructure;
using NoCond.Application.Base.Infrastructure.Interfaces;
using NoCond.Application.Base.Providers;
using NoCond.Application.Base.Providers.Interfaces;

namespace NoCond.Persistence.Registry
{
    internal class PersistenceServiceRegistry : ServiceRegistry
    {
        public PersistenceServiceRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssembliesAndExecutablesFromApplicationBaseDirectory();
                scanner.Include(
                    t =>
                        !t.GetTypeInfo().IsAbstract && !t.GetTypeInfo().IsGenericTypeDefinition &&
                        typeof(IRepository).IsAssignableFrom(t));


                scanner.WithDefaultConventions(ServiceLifetime.Transient);
            });

            For<IMainUnitOfWork>().Use(o => o.GetInstance<MainUnitOfWork>()).Scoped();
            For<IDatetimeProvider>().Use(o => o.GetInstance<DatetimeProvider>()).Scoped();
        }
    }
}