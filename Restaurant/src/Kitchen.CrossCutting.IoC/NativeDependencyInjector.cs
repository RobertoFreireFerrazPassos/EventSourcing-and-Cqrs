using MediatR;
using Kitchen.Application.Services;
using Kitchen.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Kitchen.Domain.Repositories;
using Kitchen.DataAccess.EventSourcing;
using Kitchen.Domain.Events.Base;
using Kitchen.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Kitchen.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.CrossCutting.IoC
{
    public static class NativeDependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Infra - Data EventSourcing
            services.AddDbContext<EventStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("mssqlserverConnection")));

            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();          

            // Application
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
