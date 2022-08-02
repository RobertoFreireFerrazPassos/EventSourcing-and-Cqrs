using Kitchen.Application.Services;
using Kitchen.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kitchen.CrossCutting.IoC
{
    public static class NativeDependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Application
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
