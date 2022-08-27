using Kitchen.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetMenu()
        {
            try
            {
                return Ok(_menuService.GetMenu());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
