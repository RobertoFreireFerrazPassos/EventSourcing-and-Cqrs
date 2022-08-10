using Kitchen.DataAccess.Context;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Repositories;

namespace Kitchen.DataAccess.Repositories
{
    public class ItemFromInventoryRepository : IItemFromInventoryRepository
    {
        private readonly EventStoreDbContext _eventStoreDbContext;

        public ItemFromInventoryRepository(EventStoreDbContext eventStoreDbContext)
        {
            _eventStoreDbContext = eventStoreDbContext;
        }

        public void Update(IEnumerable<ItemCopiedFromInventoryEntity> items)
        {
            _eventStoreDbContext.ItemsCopiedFromInventoryEntity.UpdateRange(items);
            _eventStoreDbContext.SaveChanges();
        }

        public IEnumerable<ItemCopiedFromInventoryEntity> GetItems(IEnumerable<Guid> itemsId)
        {
            return _eventStoreDbContext.ItemsCopiedFromInventoryEntity
                .Where(i => itemsId.Contains(i.Id));
        }
    }
}
