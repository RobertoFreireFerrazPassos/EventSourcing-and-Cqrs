using Kitchen.Domain.Events.Entities;

namespace Kitchen.Domain.Repositories
{
    public interface IEventStoreRepository
    {
        void AppendEvent(StoredEvent storedEvent);
    }
}
