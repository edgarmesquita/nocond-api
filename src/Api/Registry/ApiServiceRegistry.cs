using Lamar;
using MediatR;

namespace NoCond.Api.Registry
{
    internal class ApiServiceRegistry : ServiceRegistry
    {
        public ApiServiceRegistry ()
        {
            Scan (scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory ();
                scanner.ConnectImplementationsToTypesClosing (typeof (IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing (typeof (INotificationHandler<>));
            });

            For<IMediator> ().Use<Mediator> ().Transient ();
            For<ServiceFactory> ().Use (ctx => ctx.GetInstance);
        }
    }
}