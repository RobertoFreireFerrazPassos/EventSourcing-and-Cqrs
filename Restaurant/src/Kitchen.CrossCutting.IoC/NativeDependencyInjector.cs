using MediatR;
using Kitchen.Application.Services;
using Kitchen.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Kitchen.Domain.Repositories;
using Kitchen.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Kitchen.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Kitchen.Application.Commands;
using Kitchen.EventOutbox;
using Kitchen.Application.Queries;

namespace Kitchen.CrossCutting.IoC
{
    public static class NativeDependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterCQRS()
                    .RegisterBackgroundServices()
                    .RegisterRepositories()
                    .RegisterDbContext(configuration)
                    .RegisterApplicationServices();
        }
        private static IServiceCollection RegisterCQRS(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateOrderCommand));
            services.AddMediatR(typeof(ReserveOrderCommand));
            services.AddMediatR(typeof(CheckOrderQuery));

            return services;
        }

        private static IServiceCollection RegisterBackgroundServices(this IServiceCollection services)
        {
            services.AddHostedService<EventOutboxBackgroundService>();

            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrdersRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            
            services.AddSingleton<IIntegrationEventOutboxRepository,IntegrationEventOutboxRepository>();

            return services;
        }

        private static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KitchenDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("mssqlserverConnection")));

            return services;
        }

        private static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IMenuService, MenuService>();

            return services;
        }        
    }
}
