using System;
using System.Linq;
using eQuantic.Core.Linq.Filter;
using eQuantic.Core.Linq.Sorter;
using HealthChecks.UI.Client;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using NoCond.Api.Extensions;
using NoCond.Api.Filters;
using NoCond.Api.Swagger;
using NoCond.Application.Extensions;
using NoCond.Application.Settings;
using NoCond.Persistence;
using NoCond.Persistence.Extensions;
using NSwag;
using Serilog;

namespace NoCond.Api
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="env">The env.</param>
        public Startup (IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.environment = env;

            // Serilog logger can't be used at this point because Serilog hasn't been set yet
            this.logger = new LoggerConfiguration ()
                .ReadFrom.Configuration (configuration)
                .CreateLogger ().ForContext<Startup> ();

            this.logger.Information (
                $"Application ConfigMap{Environment.NewLine}{string.Join(Environment.NewLine, configuration.AsEnumerable())}");
        }

        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;
        private readonly ILogger logger;

        /// <summary>
        /// Configures services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices (IServiceCollection services)
        {
            logger.Information ("Starting Configure");

            services.Configure<ApplicationSettings>(configuration);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(conf =>
                {
                    conf.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            
            services.AddControllers (opt =>
            {
                opt.Filters.Add(typeof(ApiExceptionFilterAttribute));
            })
                .AddNewtonsoftJson()
                .AddSortModelBinder()
                .AddFilterModelBinder();
            
            services.AddHealthChecks ();
            services.AddApiVersioning (
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ApiVersionReader = new UrlSegmentApiVersionReader ();
                });

            services.AddVersionedApiExplorer (
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            services.Configure<ForwardedHeadersOptions> (options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            AddDocumentation (services);
            
            //sql database
            services.AddDbContext<MainContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SqlConnectionString"),
                        x => x.UseNetTopologySuite())
                , ServiceLifetime.Transient, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Configures the container.
        /// </summary>
        /// <remarks>
        /// Take in Lamar's ServiceRegistry instead of IServiceCollection
        /// as your argument, but fear not, it implements IServiceCollection
        /// as well
        /// </remarks>
        /// <param name="services">The services.</param>
        public void ConfigureContainer (ServiceRegistry services)
        {
            services
                .IncludeApplicationServiceRegistry()
                .IncludeApiServiceRegistry ()
                .IncludePersistenceServiceRegistry();

            if (environment.IsDevelopment ())
            {
                var container = new Lamar.Container (services);
                logger.Information (container.WhatDidIScan ());
                logger.Information (container.WhatDoIHave ());
            }
        }

        /// <summary>
        /// Configure.
        /// </summary>
        /// <param name="app">The app.</param>
        /// <param name="env">The env.</param>
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            logger.Information ("Starting Configure");
            var settings = app.ApplicationServices.GetService<IOptions<ApplicationSettings>>();
            
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles ();

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseCors();
            
            app.UseAuthorization ();

            app.UseEndpoints (endpoints =>
            {
                endpoints.MapControllers ();
                endpoints.MapHealthChecks ("/health", new HealthCheckOptions ()
                {
                    Predicate = _ => true,
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecks ("/liveness", new HealthCheckOptions
                {
                    Predicate = r => r.Name.Contains ("self")
                });
            });

            app.UseForwardedHeaders (new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseOpenApi ();
            app.UseSwaggerUi3 ();
            
            if (settings.Value.Database.MigrateOnStartup)
            {
                logger.Information("Applying migrations");

                using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                var dbContext = scope.ServiceProvider.GetService<MainContext>();
                dbContext.Database.Migrate();
            }

            logger.Information ("Finished Configure");
        }

        private IServiceCollection AddDocumentation (IServiceCollection services)
        {
            var sp = services.BuildServiceProvider ();
            var provider = sp.GetService<IApiVersionDescriptionProvider> ();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                services.AddOpenApiDocument ((settings, serviceProvider) =>
                {
                    settings.OperationProcessors.Add(new StringOperationProcessor<ISorting[]>());
                    settings.OperationProcessors.Add(new StringOperationProcessor<IFiltering[]>());
                    
                    settings.FlattenInheritanceHierarchy = true;
                    settings.PostProcess = document => CreateDocument (document, description);
                });
            }
            return services;
        }

        private void CreateDocument (OpenApiDocument document, ApiVersionDescription description)
        {
            document.Info.Version = description.ApiVersion.ToString ();
            configuration.Bind ("OpenApiInfo", document.Info);
            if (description.IsDeprecated)
            {
                document.Info.Description += " This API version has been deprecated.";
            }
        }
    }
}