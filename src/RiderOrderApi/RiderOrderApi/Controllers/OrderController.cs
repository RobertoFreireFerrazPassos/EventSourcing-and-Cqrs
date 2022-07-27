using Microsoft.AspNetCore.Mvc;
using RiderOrderApi.DataContracts.Requests;
using RiderOrderApi.Events;

namespace RiderOrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrder(NewOrderRequest request)
        {
            var newOrderEvent = new NewOrderEvent()
            {
                ProductId = request.ProductId,
                OrderId = request.OrderId,
                Quantity = request.Quantity,
                PricePerUnit = GetProductPrice(request.ProductId)
            };

            string message = JsonSerializer.Serialize(newOrderEvent);

            await Producer.SendMessage(OrderConstants.ORDER_TOPIC, message);

            return Ok("Order created");
        }
    }
}