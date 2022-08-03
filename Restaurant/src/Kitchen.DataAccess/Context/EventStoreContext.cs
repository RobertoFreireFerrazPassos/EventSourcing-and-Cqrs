using Kitchen.Domain.Events.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.DataAccess.Context
{
    public class EventStoreDbContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvents { get; set; }

        public EventStoreDbContext(DbContextOptions<EventStoreDbContext> options) : base(options)
        {
        }
    }
}
