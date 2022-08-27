using Kitchen.Domain.Entities.Base;

namespace Kitchen.Domain.Entities
{
    public class OrderItemEntity : Entity
    {
        public MenuItemEntity MenuItem { get; set; }
        public int Quantity { get; set; }
    }
}
