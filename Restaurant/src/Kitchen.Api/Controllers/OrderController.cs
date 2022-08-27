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
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Reserve/{orderId:Guid}")]
        public async Task<IActionResult> ReserveOrder(Guid orderId)
        {
            try
            {
                var command = new ReserveOrderCommand(orderId);
                var result = _mediator.Send(command);
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Check/{table:int}")]
        public async Task<IActionResult> GetOrder(int table)
        {
            try
            {
                var query = new CheckOrderQuery(table);
                var result = _mediator.Send(query);
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}