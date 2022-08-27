using Kitchen.DataAccess.Context;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Enums;
using Kitchen.Domain.Repositories;

namespace Kitchen.DataAccess.Repositories
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly KitchenDbContext _kitchenDbContext;

        public OrdersRepository(KitchenDbContext eventStoreDbContext)
        {
            _kitchenDbContext = eventStoreDbContext;
        }

        public void CreateOrder(StoredEventEntity storedEvent, TableEntity table, OrderEntity orderEntity)
        {
            _kitchenDbContext.StoredEvents.Add(storedEvent);
            _kitchenDbContext.Tables.Update(table);
            _kitchenDbContext.Orders.Add(orderEntity);

            _kitchenDbContext.SaveChanges();
        }

        public void UpdateOrder(StoredEventEntity storedEvent, OrderEntity orderEntity)
        {
            _kitchenDbContext.StoredEvents.Add(storedEvent);
            _kitchenDbContext.Orders.Update(orderEntity);

            _kitchenDbContext.SaveChanges();
        }

        public TableEntity? GetTable(int number)
        {
            return _kitchenDbContext.Tables.
                FirstOrDefault(t => t.Number == number);
        }

        public OrderEntity? GetActiveOrder(int table)
        {
            return _kitchenDbContext.Orders
                .FirstOrDefault(o => o.Table == table && o.Status == OrderStatus.Active);
        }

        public OrderEntity? GetOrder(Guid OrderId)
        {
            return _kitchenDbContext.Orders
                .FirstOrDefault(o => o.Id == OrderId);
        }
    }
}
