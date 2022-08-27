using Kitchen.Domain.Entities.Base;

namespace Kitchen.Domain.Entities
{
    public class TableEntity : Entity
    {
        public int Number { get; set; }
        public Guid CurrentAggregateId { get; set; }
    }
}
