using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Receipt.Api.Infra.DataAccess;

namespace Receipt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly ReceiptContext _context;

        public ReceiptController(ReceiptContext context)
        {
            _context = context;
        }

        [HttpGet("{aggregateId:Guid}")]
        public async Task<IActionResult> GetReceipt(Guid aggregateId)
        {
            try
            {
                var orders = _context.Events
                                .Where(x => x.AggregateId == aggregateId)
                                .ToList();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}