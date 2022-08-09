using Kitchen.DataAccess.Context;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Enums;
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

        public void UpdateOrder(StoredEvent storedEvent, OrderEntity orderEntity)
        {
            _eventStoreDbContext.StoredEvents.Add(storedEvent);
            _eventStoreDbContext.Orders.Update(orderEntity);

            _eventStoreDbContext.SaveChanges();
        }

        public TableEntity? GetTablesByTableId(int table)
        {
            return _eventStoreDbContext.Tables.
                FirstOrDefault(t => t.Table == table);
        }

        public OrderEntity? GetActiveOrder(int table)
        {
            return _eventStoreDbContext.Orders
                .FirstOrDefault(o => o.Table == table && o.Status == OrderStatus.Active);
        }
    }
}
