using Kitchen.Domain.Dtos;
using Kitchen.Domain.Entities.Base;
using Kitchen.Domain.Enums;

namespace Kitchen.Domain.Entities
{
    public class OrderEntity : Entity
    {
        public Guid AggregateId { get; set; }
        public int Table { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<ItemEntity> Items { get; set; }
    }
}
