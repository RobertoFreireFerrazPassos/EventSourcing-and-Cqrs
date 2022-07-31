using Inventory.Domain.Entities.Base;
using Inventory.Domain.Enums;

namespace Inventory.Domain.Entities
{
    public class ItemEntity : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ItemUnit Unit { get; set; }
    }
}
