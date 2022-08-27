using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(StoredEventEntity storedEvent, TableEntity table, OrderEntity orderEntity);
        Task UpdateOrder(StoredEventEntity storedEvent, OrderEntity orderEntity);
        Task<TableEntity?> GetTable(int number);
        Task<OrderEntity?> GetActiveOrder(int table);
        Task<OrderEntity?> GetOrder(Guid OrderId);
        Task<OrderEntity?> GetOrder(int table);
    }
}
