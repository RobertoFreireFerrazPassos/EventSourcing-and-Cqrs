using Kitchen.Domain.Entities;
using Kitchen.Domain.Events;

namespace Kitchen.Domain.Services
{
    public interface IOrderService
    {
        OrderEntity CreateOrder(OrderCreatedCommand request);
        void GetOrder();
    }
}
