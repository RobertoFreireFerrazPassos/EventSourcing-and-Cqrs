using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DataAccess.Context
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<ItemEntity> Items { get; set; }
    }
}
