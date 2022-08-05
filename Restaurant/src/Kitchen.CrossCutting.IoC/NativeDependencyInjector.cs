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

namespace Kitchen.CrossCutting.IoC
{
    public static class NativeDependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(CreateOrderCommand));

            // Infra - Data 
            services.AddScoped<IOrderRepository, OrdersRepository> ();

            services.AddDbContext<EventStoreDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("mssqlserverConnection")));                 

            // Application
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
