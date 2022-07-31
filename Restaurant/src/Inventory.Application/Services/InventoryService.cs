using Inventory.Domain.Entities;
using Inventory.Domain.Repositories;
using Inventory.Domain.Services;

namespace Inventory.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IItemRepository _inventoryRepository;

        public InventoryService(IItemRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<ItemEntity>> GetItemsAsync()
        {
            return await _inventoryRepository.GetAllAsync();
        }

        public bool ReturnItemsAsync(IEnumerable<ItemEntity> items)
        {
            return _inventoryRepository.ReturnItems(items);
        }

        public bool UseItemsAsync(IEnumerable<ItemEntity> items)
        {
            return _inventoryRepository.UseItems(items);
        }

        public void UpdateItems(IEnumerable<ItemEntity> items)
        {
            _inventoryRepository.UpdateRange(items);
        }
    }
}
