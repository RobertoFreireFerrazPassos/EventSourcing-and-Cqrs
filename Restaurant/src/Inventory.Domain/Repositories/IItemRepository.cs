using Inventory.Domain.Entities;

namespace Inventory.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>> GetAllAsync();
        void UpdateRange(IEnumerable<ItemEntity> items);
        bool UseItems(IEnumerable<ItemEntity> items);
        bool ReturnItems(IEnumerable<ItemEntity> items);
    }
}
