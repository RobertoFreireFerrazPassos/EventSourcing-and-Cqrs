namespace Inventory.Domain.Services
{
    public interface IInventoryService
    {
        public Task<ItemsResponse> GetItemsAsync();

        public Task<ItemsResponse> UpdateItemsAsync();
    }
}
