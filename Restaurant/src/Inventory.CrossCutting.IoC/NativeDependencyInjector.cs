using Inventory.Application.Services;
using Inventory.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.CrossCutting.IoC
{
    public class NativeDependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services  

            services.AddScoped<IInventoryService, InventoryService>();

            #endregion
        }
    }
}
