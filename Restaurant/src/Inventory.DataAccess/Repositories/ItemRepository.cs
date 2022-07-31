using Inventory.DataAccess.Context;
using Inventory.Domain.Entities;
using Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private DbContextOptions<InventoryContext> _options = new DbContextOptionsBuilder<InventoryContext>()
               .UseInMemoryDatabase(databaseName: "Inventory")
               .Options;

        public async Task<IEnumerable<ItemEntity>> GetAll()
        {
            using (var context = new InventoryContext(_options))
            {
                return await context.Inventory.ToListAsync();
            }
        }

        public void UpdateRange(IEnumerable<ItemEntity> items)
        {
            using (var context = new InventoryContext(_options))
            {
                context.Inventory.UpdateRange(items);
                context.SaveChanges();
            }
        }
    }
}
