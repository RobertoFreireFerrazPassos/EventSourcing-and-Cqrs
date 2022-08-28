using Kitchen.DataAccess.Context;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kitchen.DataAccess.Repositories
{
    public class IntegrationEventOutboxRepository : IIntegrationEventOutboxRepository
    {
        private KitchenDbContext _kitchenDbContext;
        private readonly IServiceProvider _serviceProvider;

        public IntegrationEventOutboxRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<IntegrationEventOutbox>> GetIntegrationEventsOutbox(CancellationToken stoppingToken)
        {

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                _kitchenDbContext = scope.ServiceProvider.GetRequiredService<KitchenDbContext>();

                return await _kitchenDbContext
                    .IntegrationEventsOutbox
                    .Include(ie => ie.Event)
                    .ToListAsync(stoppingToken);
            }            
        }

        public void DeleteIntegrationEventsOutbox(IEnumerable<IntegrationEventOutbox> integrationEvents)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                _kitchenDbContext = scope.ServiceProvider.GetRequiredService<KitchenDbContext>();

                _kitchenDbContext
                .IntegrationEventsOutbox
                .RemoveRange(integrationEvents);

                _kitchenDbContext.SaveChanges();
            }            
        }
    }
}
