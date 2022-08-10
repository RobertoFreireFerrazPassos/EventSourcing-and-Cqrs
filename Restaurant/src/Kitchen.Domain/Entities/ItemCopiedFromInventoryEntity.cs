using Kitchen.Domain.Entities.Base;

namespace Kitchen.Domain.Entities
{
    public class ItemCopiedFromInventoryEntity : Entity
    {
        public Guid ItemIdFromInventory { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
