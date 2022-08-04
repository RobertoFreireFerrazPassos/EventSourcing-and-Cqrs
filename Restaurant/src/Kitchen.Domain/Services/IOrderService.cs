using Kitchen.Domain.Events;

namespace Kitchen.Domain.Services
{
    public interface IOrderService
    {
        OrderCreatedEvent CreateOrder(OrderCreatedEvent request);
        void GetOrder();
    }
}
