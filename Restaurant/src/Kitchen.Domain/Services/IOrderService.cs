using Kitchen.Domain.Events;

namespace Kitchen.Domain.Services
{
    public interface IOrderService
    {
        void CreateOrder(OrderCreatedEvent request);
        void GetOrder();
    }
}
