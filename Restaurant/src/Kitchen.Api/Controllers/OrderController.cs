using Kitchen.Application.DataContracts.Requests;
using Kitchen.Application.Extensions.Mapping;
using Kitchen.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            try
            {
                request.MapCreateOrderRequest();

                _orderService.CreateOrder();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequest request)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Cancel/{tableid:int}")]
        public async Task<IActionResult> CancelOrder(int tableid)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Check/{tableid:int}")]
        public async Task<IActionResult> GetOrder(int tableid)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Reserve/{tableid:int}")]
        public async Task<IActionResult> ReserveOrder(int tableid)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Complete/{tableid:int}")]
        public async Task<IActionResult> CompleteOrder(int tableid)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}