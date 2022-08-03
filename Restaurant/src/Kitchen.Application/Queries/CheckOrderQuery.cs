using Kitchen.Application.DataContracts.Responses;
using MediatR;

namespace Kitchen.Application.Queries
{
    public class CheckOrderQuery : IRequest<OrderResponse>
    {
    }
}
