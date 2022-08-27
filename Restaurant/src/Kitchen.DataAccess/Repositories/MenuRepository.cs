using Kitchen.DataAccess.Context;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.DataAccess.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly KitchenDbContext _dbContext;

        public MenuRepository(KitchenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MenuItemEntity>> GetAllAsync()
        {
            return await _dbContext.MenuItems.ToListAsync();
        }
    }
}
