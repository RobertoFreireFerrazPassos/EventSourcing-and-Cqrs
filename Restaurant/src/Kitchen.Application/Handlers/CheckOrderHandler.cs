using Kitchen.Application.DataContracts.Responses;
using Kitchen.Application.Queries;
using Kitchen.Domain.Dtos;
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

        public async Task<OrderResponse> Handle(CheckOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetOrder(request.Table);

            return new OrderResponse()
            {
                Id = result.Id,
                AggregateId = result.AggregateId,
                Table = result.Table,
                Status = result.Status,
                Items = result.Items.Select(i => new Item()
                {
                    Name = i.MenuItem.Name,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
    }
}
