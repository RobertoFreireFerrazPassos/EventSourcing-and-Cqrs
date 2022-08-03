using Kitchen.DataAccess.Context;
using Kitchen.Domain.Events.Entities;
using Kitchen.Domain.Repositories;

namespace Kitchen.DataAccess.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreDbContext _dbContext;

        public EventStoreRepository(EventStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AppendEvent(StoredEvent storedEvent)
        {
            _dbContext.StoredEvents.Add(storedEvent);
            _dbContext.SaveChanges();
        }
    }
}
