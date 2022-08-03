using MediatR;
using Kitchen.Application.Services;
using Kitchen.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Kitchen.Domain.Repositories;
using Kitchen.DataAccess.EventSourcing;
using Kitchen.DataAccess.Context;
using Kitchen.Domain.Events.Base;
using Kitchen.DataAccess.Repositories;

namespace Kitchen.CrossCutting.IoC
{
    public static class NativeDependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Application
            services.AddScoped<IOrderService, OrderService>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreContext>();
        }
    }
}
