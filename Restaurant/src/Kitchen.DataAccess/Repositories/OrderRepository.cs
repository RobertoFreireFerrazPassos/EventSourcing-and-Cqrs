using Kitchen.DataAccess.Context;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Enums;
using Kitchen.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.DataAccess.Repositories
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly KitchenDbContext _kitchenDbContext;

        public OrdersRepository(KitchenDbContext eventStoreDbContext)
        {
            _kitchenDbContext = eventStoreDbContext;
        }

        public async Task CreateOrder(StoredEventEntity storedEvent, TableEntity table, OrderEntity orderEntity)
        {
            var integrationEvent = new IntegrationEventOutbox();
            integrationEvent.Event = storedEvent;

            _kitchenDbContext.StoredEvents.Add(storedEvent);            
            _kitchenDbContext.IntegrationEventsOutbox.Add(integrationEvent);
            _kitchenDbContext.Tables.Update(table);
            _kitchenDbContext.Orders.Add(orderEntity);

            _kitchenDbContext.SaveChanges();
        }

        public async Task UpdateOrder(StoredEventEntity storedEvent, OrderEntity orderEntity)
        {
            var integrationEvent = new IntegrationEventOutbox();
            integrationEvent.Event = storedEvent;

            _kitchenDbContext.StoredEvents.Add(storedEvent);
            _kitchenDbContext.IntegrationEventsOutbox.Add(integrationEvent);
            _kitchenDbContext.Orders.Update(orderEntity);

            _kitchenDbContext.SaveChanges();
        }

        public async Task<OrderEntity?> GetActiveOrder(int table)
        {
            return _kitchenDbContext.Orders
                .FirstOrDefault(o => o.Table == table && o.Status == OrderStatus.Active);
        }

        public async Task<OrderEntity?> GetOrder(Guid OrderId)
        {
            return _kitchenDbContext.Orders
                .FirstOrDefault(o => o.Id == OrderId);
        }

        public async Task<OrderEntity?> GetOrder(int table, Guid aggregateId)
        {
            return _kitchenDbContext.Orders
                .Include(o => o.Items).ThenInclude(i => i.MenuItem)
                .FirstOrDefault(o => o.Table == table && o.AggregateId == aggregateId);
        }

        // TO DO: create new repositories
        #region create new repositories
        public async Task<TableEntity?> GetTable(int number)
        {
            return _kitchenDbContext.Tables.
                FirstOrDefault(t => t.Number == number);
        }

        public async Task<IEnumerable<IntegrationEventOutbox>> GetIntegrationEventsOutbox()
        {
            return await _kitchenDbContext.IntegrationEventsOutbox.ToListAsync();
        }
        public void DeleteIntegrationEventsOutbox(IEnumerable<IntegrationEventOutbox> integrationEvents)
        {
            _kitchenDbContext
                .IntegrationEventsOutbox
                .RemoveRange(integrationEvents);

            _kitchenDbContext.SaveChanges();
        }
        #endregion
    }
}
