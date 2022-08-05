using Kitchen.Domain.Entities.Base;

namespace Kitchen.Domain.Entities
{
    public class ItemEntity : Entity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
