using Kitchen.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen.Domain.Events.Entities
{
    public class StoredEvent : Event
    {
        public Guid Id { get; private set; }

        [Column(TypeName = "jsonb")]
        public string Data { get; private set; }

        protected StoredEvent() { }

        public StoredEvent(string messageType, Guid aggregateId, string data)
        {
            Id = Guid.NewGuid();
            AggregateId = aggregateId;
            MessageType = messageType;
            Data = data;
        }
    }
}
