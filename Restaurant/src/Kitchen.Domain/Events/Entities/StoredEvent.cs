using Kitchen.Domain.Events.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen.Domain.Events.Entities
{
    public class StoredEvent : Event
    {
        public Guid Id { get; private set; }

        [Column(TypeName = "jsonb")]
        public string Data { get; private set; }
        protected StoredEvent() { }
        public StoredEvent(Event theEvent, string data)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
        }
    }
}
