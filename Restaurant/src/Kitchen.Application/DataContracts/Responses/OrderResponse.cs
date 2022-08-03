using Kitchen.Application.DataContracts.Data;

namespace Kitchen.Application.DataContracts.Responses
{
    public class OrderResponse
    {
        public int Table { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
