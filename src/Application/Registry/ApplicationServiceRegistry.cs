using System.Reflection;
using AutoMapper;
using eQuantic.Core.Extensions;
using FluentValidation;
using Lamar;
using Lamar.Scanning.Conventions;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Base.Validators;

namespace NoCond.Application.Registry
{
    internal class ApplicationServiceRegistry : ServiceRegistry
    {
        public ApplicationServiceRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory(o => 
                    o.GetName().FullName.StartsWith("NoCond"));
                
                scanner.Include(
                    t =>
                        !t.GetTypeInfo().IsAbstract && !t.GetTypeInfo().IsGenericTypeDefinition &&
                        typeof(IApplicationService).IsAssignableFrom(t));

                scanner.WithDefaultConventions(OverwriteBehavior.Never);
            });

            Scan(scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory(o => 
                    o.GetName().FullName.StartsWith("NoCond"));
                scanner.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
            });
            
            For<IValidatorFactory>().Use<ValidatorFactory>();
            
            For<MapperConfiguration>().Use(o => new MapperConfiguration(c => SetMapperConfiguration(o, c))).Scoped();
            For<IConfigurationProvider>().Use(o => o.GetInstance<MapperConfiguration>()).Scoped();
            For<IMapper>().Use(o => o.GetInstance<MapperConfiguration>().CreateMapper()).Scoped();

            Scan(scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory(o => 
                    o.GetName().FullName.StartsWith("NoCond"));
                scanner.Include(
                    t =>
                        !t.GetTypeInfo().IsAbstract && !t.GetTypeInfo().IsGenericTypeDefinition &&
                        typeof(Profile).IsAssignableFrom(t));

                scanner.AddAllTypesOf<Profile>();
            });
        }
        
        private static void SetMapperConfiguration(IServiceContext o, IMapperConfigurationExpression c)
        {
            c.ConstructServicesUsing(o.GetInstance);
            o.GetAllInstances<Profile>().ForEach(c.AddProfile);
        }
    }
}