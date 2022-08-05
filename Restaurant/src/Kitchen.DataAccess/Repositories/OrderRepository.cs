using Kitchen.DataAccess.Context;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Events.Entities;
using Kitchen.Domain.Repositories;

namespace Kitchen.DataAccess.Repositories
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly EventStoreDbContext _eventStoreDbContext;

        public OrdersRepository(EventStoreDbContext eventStoreDbContext)
        {
            _eventStoreDbContext = eventStoreDbContext;
        }

        public void CreateOrder(StoredEvent storedEvent, TableEntity table, OrderEntity orderEntity)
        {
            _eventStoreDbContext.StoredEvents.Add(storedEvent);
            _eventStoreDbContext.Tables.Update(table);
            _eventStoreDbContext.Orders.Add(orderEntity);

            _eventStoreDbContext.SaveChanges();
        }
    }
}
