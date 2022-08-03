using Kitchen.Application.Commands;
using Kitchen.Domain.Events;
using Kitchen.Domain.Events.Base;
using Kitchen.Domain.Services;

namespace Kitchen.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IEventStore _eventStore;

        public OrderService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void CreateOrder(OrderCreatedEvent orderCreatedEvent)
        {
            _eventStore.Save(orderCreatedEvent);
        }

        public void GetOrder()
        {
            
        }
    }
}
