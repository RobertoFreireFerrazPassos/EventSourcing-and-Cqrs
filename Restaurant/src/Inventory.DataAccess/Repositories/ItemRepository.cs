using Inventory.DataAccess.Context;
using Inventory.Domain.Entities;
using Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly InventoryDbContext _dbContext;

        public ItemRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ItemEntity>> GetAllAsync()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public bool ReturnItems(IEnumerable<ItemEntity> items)
        {
            var itemsToUse = items.Select(i => i.Id).ToList();

            var itemsFound = _dbContext.Items.Where(i => itemsToUse.Contains(i.Id));

            if (itemsFound.Count() != itemsToUse.Count)
            {
                return false;
            }

            foreach (var itemFound in itemsFound)
            {
                var currentItem = items.FirstOrDefault(i => i.Id == itemFound.Id);

                itemFound.Quantity = itemFound.Quantity + currentItem.Quantity;

                _dbContext.Items.Attach(itemFound).Property(i => i.Quantity).IsModified = true;
            }

            _dbContext.SaveChanges();

            return true;
        }

        public bool UseItems(IEnumerable<ItemEntity> items)
        {
            var itemsToUse = items.Select(i => i.Id).ToList();

            var itemsFound = _dbContext.Items.Where(i => itemsToUse.Contains(i.Id));

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

                _dbContext.Items.Attach(itemFound).Property(i => i.Quantity).IsModified = true;
            }

            _dbContext.SaveChanges();

            return true;
        }        

        public void UpdateRange(IEnumerable<ItemEntity> items)
        {
            _dbContext.Items.UpdateRange(items);
            _dbContext.SaveChanges();
        }
    }
}
