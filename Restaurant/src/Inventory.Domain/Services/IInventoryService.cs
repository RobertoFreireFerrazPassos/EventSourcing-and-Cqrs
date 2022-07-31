using Inventory.Domain.Entities;

namespace Inventory.Domain.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<ItemEntity>> GetItemsAsync();
        void UpdateItems(IEnumerable<ItemEntity> items);
        bool ReturnItemsAsync(IEnumerable<ItemEntity> items);
        bool UseItemsAsync(IEnumerable<ItemEntity> items);
    }
}
