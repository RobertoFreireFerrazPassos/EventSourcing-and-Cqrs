using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Repositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<MenuItemEntity>> GetAllAsync();
    }
}
