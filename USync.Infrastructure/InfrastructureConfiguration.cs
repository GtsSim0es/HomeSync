using USync.Application.Interfaces;
using USync.Infrastructure.Data.ApplicationDB;
using USync.Infrastructure.Repositories;
using USync.Infrastructure.Transctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using USync.Application.Handlers;
using USync.Application;
using USync.Application.Handlers.Contracts;
using USync.Application.Commands;

namespace USync.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            //services.AddLogging();

            AddContexts(services, configuration, serviceLifetime);
            AddRepositories(services, serviceLifetime);
            AddCommanders(services);
        }

        private static void AddContexts(IServiceCollection services, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            var connectionString = configuration.GetConnectionString("MainConnection") ?? throw new InvalidOperationException("Connection string 'MainConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(connectionString), serviceLifetime);
        }

        private static void AddCommanders(IServiceCollection services)
        {
            services.AddTransient<IHandler<AuthenticateUserCommand>, UserHandler>();
            services.AddTransient<IHandler<RegisterUserCommand>, UserHandler>();
            services.AddTransient<IHandler<TaskCreateCommand>, TasksHandler>();
            services.AddTransient<IHandler<CalendarCreateEventCommand>, CalendarEventHandler>();
        }

        private static void AddRepositories(IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.AddDynamic<IUnitOfWork, UnitOfWork>(serviceLifetime);
            services.AddDynamic<IUsersRepository, UsersRepository>(serviceLifetime);
            services.AddDynamic<ICalendarRepository, CalendarRepository>(serviceLifetime);
            services.AddDynamic<ITasksRepository, TasksRepository>(serviceLifetime);
        }


        private static void AddDynamic<TInterface, TClass>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        where TClass : class, TInterface
        where TInterface : class
        {
            services.Add(new ServiceDescriptor(typeof(TInterface), typeof(TClass), lifetime));
        }

    }
}
