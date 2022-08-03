using Kitchen.Domain.Events.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.DataAccess.Context
{
    public class EventStoreContext : DbContext
    {
        public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options) { }

        public DbSet<StoredEvent> StoredEvents { get; set; }
    }
}
