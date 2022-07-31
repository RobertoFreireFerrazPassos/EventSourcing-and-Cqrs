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

        public async Task<IEnumerable<ItemEntity>> GetAllAsync()
        {
            using (var context = new InventoryContext(_options))
            {
                return await context.Inventory.ToListAsync();
            }
        }

        public bool ReturnItems(IEnumerable<ItemEntity> items)
        {
            var itemsToUse = items.Select(i => i.Id).ToList();

            using (var context = new InventoryContext(_options))
            {
                var itemsFound = context.Inventory.Where(i => itemsToUse.Contains(i.Id));

                if (itemsFound.Count() != itemsToUse.Count)
                {
                    return false;
                }

                foreach (var itemFound in itemsFound)
                {
                    var currentItem = items.FirstOrDefault(i => i.Id == itemFound.Id);

                    itemFound.Quantity = itemFound.Quantity + currentItem.Quantity;

                    context.Inventory.Attach(itemFound).Property(i => i.Quantity).IsModified = true;
                }

                context.SaveChanges();
            }

            return true;
        }

        public bool UseItems(IEnumerable<ItemEntity> items)
        {
            var itemsToUse = items.Select(i => i.Id).ToList();

            using (var context = new InventoryContext(_options))
            {
                var itemsFound = context.Inventory.Where(i => itemsToUse.Contains(i.Id));

                if (itemsFound.Count() != itemsToUse.Count)
                {
                    return false;
                }                

                foreach (var itemFound in itemsFound)
                {
                    var currentItem = items.FirstOrDefault(i => i.Id == itemFound.Id);

                    if (currentItem is null)
                    {
                        return false;
                    }

                    var countDifference = itemFound.Quantity - currentItem.Quantity;

                    if (countDifference < 0)
                    {
                        return false;
                    }

                    itemFound.Quantity = countDifference;

                    context.Inventory.Attach(itemFound).Property(i => i.Quantity).IsModified = true;
                }

                context.SaveChanges();
            }

            return true;
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
