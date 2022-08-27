using Kitchen.Domain.Entities;
using Kitchen.Domain.Repositories;
using Kitchen.Domain.Services;

namespace Kitchen.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<MenuItemEntity>> GetMenu()
        {
            return await _menuRepository.GetAllAsync();
        }
    }
}
