using Inventory.Domain.Entities;

namespace Inventory.Domain.Services
{
    public interface IInventoryService
    {
        public Task<IEnumerable<ItemEntity>> GetItemsAsync();

        public void UpdateItems(IEnumerable<ItemEntity> items);
    }
}
