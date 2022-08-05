using Kitchen.Domain.Enums;

namespace Kitchen.Domain.Dtos
{
    public class OrderCreated
    {
        public Guid Id { get; set; }
        public int Table { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
