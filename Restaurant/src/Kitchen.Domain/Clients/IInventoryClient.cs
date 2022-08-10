using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Clients
{
    public interface IInventoryClient
    {
        public Task<bool> GetItems(IEnumerable<ItemEntity> items);
        public Task<bool> ReturnItem(IEnumerable<ItemCopiedFromInventoryEntity> items);
    }
}
