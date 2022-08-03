using MediatR;
using Kitchen.Application.Services;
using Kitchen.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kitchen.CrossCutting.IoC
{
    public static class NativeDependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Application
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
