using Kitchen.Application.Commands;
using Kitchen.Application.DataContracts.Requests;
using Kitchen.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            try
            {
                var command = new CreateOrderCommand(request);
                var result = _mediator.Send(command);
                return Ok(result);
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
                var query = new CheckOrderQuery();
                var result = _mediator.Send(query);
                return Ok(result);
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