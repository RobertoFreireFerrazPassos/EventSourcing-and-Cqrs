using Kitchen.Domain.Events.Base;

namespace Kitchen.Domain.Events
{
    public class OrderCreatedEvent : Event
    {
        public OrderCreatedEvent(Guid id)
        {
            AggregateId = id;
        }        
    }
}
