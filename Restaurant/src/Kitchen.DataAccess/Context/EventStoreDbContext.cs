using Kitchen.Domain.Entities;
using Kitchen.Domain.Events.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.DataAccess.Context
{
    public class EventStoreDbContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvents { get; set; }

        public DbSet<TableEntity> Tables { get; set; }

        public DbSet<ItemEntity> Items { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }        

        public EventStoreDbContext(DbContextOptions<EventStoreDbContext> options) : base(options)
        {
        }
    }
}
