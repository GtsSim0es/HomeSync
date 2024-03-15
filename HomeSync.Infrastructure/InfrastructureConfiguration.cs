using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSync.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        private static IConfiguration? Configuration { get; set; }

        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            Configuration = configuration;

            //services.AddLogging();

            //var connectionString = Configuration.GetConnectionString("ImpactoContext");
            //services.AddDbContext<ImpactoContext>(opt => opt.UseSqlServer(connectionString), serviceLifetime);

            //services.AddDynamic<IMessagesApiAdapter, ChatbeeApiAdapter>(serviceLifetime);
            //services.AddDynamic<IMessagesRepository, MessagesRepository>(serviceLifetime);

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
