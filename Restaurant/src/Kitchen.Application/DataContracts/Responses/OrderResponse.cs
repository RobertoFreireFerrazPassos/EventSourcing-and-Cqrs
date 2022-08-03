using Kitchen.Domain.Dtos;

namespace Kitchen.Application.DataContracts.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public int Table { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
