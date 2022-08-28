using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Repositories
{
    public interface IIntegrationEventOutboxRepository
    {
        Task<IEnumerable<IntegrationEventOutbox>> GetIntegrationEventsOutbox(CancellationToken stoppingToken);
        void DeleteIntegrationEventsOutbox(IEnumerable<IntegrationEventOutbox> integrationEvents);
    }
}
