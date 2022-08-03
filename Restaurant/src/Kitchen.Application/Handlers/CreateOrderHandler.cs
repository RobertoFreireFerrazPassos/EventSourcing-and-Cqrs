using Kitchen.Application.Commands;
using Kitchen.Application.DataContracts.Responses;
using Kitchen.Application.Services;
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

        public Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _orderService.CreateOrder(request);
            return null;
        }
    }
}
