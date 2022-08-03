using Kitchen.Application.Commands;
using Kitchen.Domain.Events;
using Kitchen.Domain.Events.Base;

namespace Kitchen.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IEventStore _eventStore;

        public OrderService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void CreateOrder(CreateOrderCommand request)
        {
            var orderCreatedEvent = new OrderCreatedEvent(request.Id);
            _eventStore.Save(orderCreatedEvent);
        }

        public void GetOrder()
        {
            
        }
    }
}
