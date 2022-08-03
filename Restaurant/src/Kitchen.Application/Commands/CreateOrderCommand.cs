using Kitchen.Application.DataContracts.Responses;
using MediatR;

namespace Kitchen.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
    }
}
