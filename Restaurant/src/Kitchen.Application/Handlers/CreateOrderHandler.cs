using Kitchen.Application.Commands;
using Kitchen.Application.DataContracts.Responses;
using Kitchen.Domain.Enums;
using Kitchen.Domain.Events;
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

        public Task<OrderResponse> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderCreatedEvent = new OrderCreatedEvent(command.Request.Table, command.Request.Items);
            var result = _orderService.CreateOrder(orderCreatedEvent);

            return Task.FromResult(new OrderResponse()
            {
                Id = result.AggregateId,
                Table = result.Table,
                Status = OrderStatus.Active,
                Items = result.Items
            });
        }
    }
}
