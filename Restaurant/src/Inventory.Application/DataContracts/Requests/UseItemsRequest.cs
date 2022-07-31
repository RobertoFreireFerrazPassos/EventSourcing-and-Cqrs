using Inventory.Application.DataContracts.Data;

namespace Inventory.Application.DataContracts.Requests
{
    public class UseItemsRequest
    {
        public IEnumerable<QuantityItem> Items { get; set; }
    }
}
