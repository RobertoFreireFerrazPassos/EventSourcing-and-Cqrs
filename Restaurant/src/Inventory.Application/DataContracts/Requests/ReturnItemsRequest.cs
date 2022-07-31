using Inventory.Application.DataContracts.Data;

namespace Inventory.Application.DataContracts.Requests
{
    public class ReturnItemsRequest
    {
        public IEnumerable<QuantityItem> Items { get; set; }
    }
}
