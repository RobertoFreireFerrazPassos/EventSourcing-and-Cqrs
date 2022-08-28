using Kitchen.Domain.Entities.Base;

namespace Kitchen.Domain.Entities
{
    public class IntegrationEventOutbox : Entity
    {
        public StoredEventEntity Event { get; set; }
    }
}
