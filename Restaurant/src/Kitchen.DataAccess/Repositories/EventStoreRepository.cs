using Kitchen.DataAccess.Context;
using Kitchen.Domain.Events.Entities;
using Kitchen.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.DataAccess.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private DbContextOptions<EventStoreContext> _options = new DbContextOptionsBuilder<EventStoreContext>()
               .UseInMemoryDatabase(databaseName: "EventStore")
               .Options;

        public void AppendEvent(StoredEvent storedEvent)
        {
            using (var context = new EventStoreContext(_options))
            {
                context.StoredEvents.Add(storedEvent);
                context.SaveChanges();
            }
        }
    }
}
