using Kitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.DataAccess.Context
{
    public class KitchenDbContext : DbContext
    {
        public DbSet<MenuItemEntity> MenuItems { get; set; }
        public DbSet<TableEntity> Tables { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<StoredEventEntity> StoredEvents { get; set; }
        public DbSet<IntegrationEventOutbox> IntegrationEventsOutbox { get; set; }        

        public KitchenDbContext(DbContextOptions<KitchenDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItemEntity>().HasData(
                new MenuItemEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Soup"
                }
            );

            modelBuilder.Entity<TableEntity>().HasData(
                new TableEntity
                {
                    Id = Guid.NewGuid(),
                    Number = 1
                },
                new TableEntity
                {
                    Id = Guid.NewGuid(),
                    Number = 2
                },
                new TableEntity
                {
                    Id = Guid.NewGuid(),
                    Number = 3
                },
                new TableEntity
                {
                    Id = Guid.NewGuid(),
                    Number = 4
                }
            );
        }
    }
}
