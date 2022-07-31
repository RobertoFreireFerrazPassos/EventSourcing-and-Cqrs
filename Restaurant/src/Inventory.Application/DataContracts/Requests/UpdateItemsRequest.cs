using Inventory.Application.DataContracts.Data;

namespace Inventory.Application.DataContracts.Requests
{
    public class UpdateItemsRequest
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
