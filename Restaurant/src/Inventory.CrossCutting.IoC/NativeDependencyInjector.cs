using Inventory.Application.Infra.AutoMapper;
using Inventory.Application.Services;
using Inventory.DataAccess.Context;
using Inventory.DataAccess.Repositories;
using Inventory.Domain.Repositories;
using Inventory.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.CrossCutting.IoC
{
    public static class NativeDependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Application
            services.AddScoped<IInventoryService, InventoryService>();

            // Application - AutoMapper
            AutoMapperConfiguration.RegisterMappings(services);

            // Infra - Data
            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
