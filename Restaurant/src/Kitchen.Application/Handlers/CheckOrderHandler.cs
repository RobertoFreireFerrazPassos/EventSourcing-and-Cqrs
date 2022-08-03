using Kitchen.Application.DataContracts.Responses;
using Kitchen.Application.Queries;
using Kitchen.Domain.Services;
using MediatR;

namespace Kitchen.Application.Handlers
{
    public class CheckOrderHandler : IRequestHandler<CheckOrderQuery, OrderResponse>
    {
        private readonly IOrderService _orderService;
        public CheckOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<OrderResponse> Handle(CheckOrderQuery request, CancellationToken cancellationToken)
        {
            _orderService.GetOrder();
            return null;
        }
    }
}
