using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Repositories
{
    public interface IItemFromInventoryRepository
    {
        public void Update(IEnumerable<ItemCopiedFromInventoryEntity> items);

        public IEnumerable<ItemCopiedFromInventoryEntity> GetItems(IEnumerable<Guid> itemsId);
    }
}
