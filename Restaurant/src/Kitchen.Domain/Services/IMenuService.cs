using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuItemEntity>> GetMenu();
    }
}
