using Kitchen.Domain.Events.Base;
using Kitchen.Domain.Events.Entities;
using Kitchen.Domain.Repositories;
using Newtonsoft.Json;

namespace Kitchen.DataAccess.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData);

            _eventStoreRepository.AppendEvent(storedEvent);
        }
    }
}
