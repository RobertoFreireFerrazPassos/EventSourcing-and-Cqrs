using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DataAccess.Context
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<ItemEntity> Items { get; set; }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }
    }
}
