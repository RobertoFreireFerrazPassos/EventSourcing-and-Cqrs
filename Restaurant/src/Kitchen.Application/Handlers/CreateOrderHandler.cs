using Kitchen.Application.Commands;
using Kitchen.Application.DataContracts.Responses;
using Kitchen.Domain.Dtos;
using Kitchen.Domain.Enums;
using Kitchen.Domain.Services;
using MediatR;

namespace Kitchen.Application.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrderService _orderService;
        public CreateOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<OrderResponse> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderCreatedCommand = new OrderCreatedCommand(command.Request.Table, command.Request.Items);
            var result = await _orderService.CreateOrder(orderCreatedCommand);

            return new OrderResponse()
            {
                Id = result.Id,
                AggregateId = result.AggregateId,
                Table = result.Table,
                Status = OrderStatus.Active,
                Items = result.Items.Select(i => new Item()
                {
                    Name = i.MenuItem.Name,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
    }
}
