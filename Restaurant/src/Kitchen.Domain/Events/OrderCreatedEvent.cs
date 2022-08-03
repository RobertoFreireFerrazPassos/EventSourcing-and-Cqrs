using Kitchen.Domain.Dtos;
using Kitchen.Domain.Events.Base;

namespace Kitchen.Domain.Events
{
    public class OrderCreatedEvent : Event
    {
        public int Table { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public OrderCreatedEvent(int table, IEnumerable<Item> item)
        {
            AggregateId = Guid.NewGuid();
            Table = table;
            Items = item;
        }        
    }
}
