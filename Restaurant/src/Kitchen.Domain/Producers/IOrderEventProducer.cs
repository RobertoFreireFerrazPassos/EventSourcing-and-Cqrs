using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Producers
{
    public interface IOrderEventProducer
    {
        public Task<bool> Publish(StoredEventEntity storedEventEvent);
    }
}
