using Kitchen.Domain.Entities;
using Kitchen.Domain.Events.Entities;

namespace Kitchen.Domain.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(StoredEvent storedEvent, TableEntity table, OrderEntity orderEntity);
    }
}
