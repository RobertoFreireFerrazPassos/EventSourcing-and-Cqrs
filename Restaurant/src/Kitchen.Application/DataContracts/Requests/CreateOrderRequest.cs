using Kitchen.Application.DataContracts.Data;

namespace Kitchen.Application.DataContracts.Requests
{
    public class CreateOrderRequest
    {
        public int Table { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
