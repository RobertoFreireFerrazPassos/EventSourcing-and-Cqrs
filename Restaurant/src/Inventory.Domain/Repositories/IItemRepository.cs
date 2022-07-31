using Inventory.Domain.Entities;

namespace Inventory.Domain.Repositories
{
    public interface IItemRepository
    {
        public Task<IEnumerable<ItemEntity>> GetAll();

        public void UpdateRange(IEnumerable<ItemEntity> items);
    }
}
