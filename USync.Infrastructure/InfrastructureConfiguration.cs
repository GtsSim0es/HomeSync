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
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            services.TryAddTransient<IHandler<AuthenticateUserCommand>, UserHandler>();
            services.TryAddTransient<IHandler<RegisterUserCommand>, UserHandler>();
            services.TryAddTransient<IHandler<TaskCreateCommand>, TasksHandler>();
            services.TryAddTransient<IHandler<TaskRemoveCommand>, TasksHandler>();
            services.TryAddTransient<IHandler<CalendarCreateEventCommand>, CalendarEventHandler>();
            services.TryAddTransient<IHandler<CalendarRemoveEventCommand>, CalendarEventHandler>();
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
