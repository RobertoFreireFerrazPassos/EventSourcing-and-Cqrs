using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(StoredEventEntity storedEvent, TableEntity table, OrderEntity orderEntity);
        void UpdateOrder(StoredEventEntity storedEvent, OrderEntity orderEntity);
        public TableEntity? GetTable(int number);
        OrderEntity? GetActiveOrder(int table);
        OrderEntity? GetOrder(Guid OrderId);
    }
}
