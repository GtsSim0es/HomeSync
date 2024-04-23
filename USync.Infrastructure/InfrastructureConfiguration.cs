using USync.Application.Interfaces;
using USync.Infrastructure.Data.ApplicationDB;
using USync.Infrastructure.Repositories;
using USync.Infrastructure.Transctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using USync.Application.Handlers;

namespace USync.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        private static IConfiguration? Configuration { get; set; }

        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            Configuration = configuration;

            //services.AddLogging();

            var connectionString = Configuration.GetConnectionString("MainConnection") ?? throw new InvalidOperationException("Connection string 'MainConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(connectionString), serviceLifetime);

            services.AddDynamic<IUnitOfWork, UnitOfWork>(serviceLifetime);
            services.AddDynamic<IUsersRepository, UsersRepository>(serviceLifetime);


            services.AddTransient<UserHandler, UserHandler>();
        }

        private static void AddDynamic<TInterface, TClass>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        where TClass : class, TInterface
        where TInterface : class
        {
            services.Add(new ServiceDescriptor(typeof(TInterface), typeof(TClass), lifetime));
        }

        internal static string EnviarMensagemUrl
        {
            get
            {
                var conn = Configuration?.GetConnectionString("urlEnviarMensagem") ?? String.Empty;
                return conn;
            }
        }
        internal static string StatusAtendimentoUrl
        {
            get
            {
                var conn = Configuration?.GetConnectionString("urlStatusAtendimento") ?? String.Empty;
                return conn;
            }
        }
        internal static string LocalApiUrl
        {
            get
            {
                var conn = Configuration?.GetConnectionString("urlApi") ?? String.Empty;
                return conn;
            }
        }
    }
}
