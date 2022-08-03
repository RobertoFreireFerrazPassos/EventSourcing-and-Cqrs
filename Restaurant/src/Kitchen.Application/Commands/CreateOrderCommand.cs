using Kitchen.Application.DataContracts.Requests;
using Kitchen.Application.DataContracts.Responses;
using MediatR;

namespace Kitchen.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public Guid Id { get; private set; }
        public CreateOrderRequest Request { get; set; }

        public CreateOrderCommand(CreateOrderRequest request)
        {
            Id = Guid.NewGuid();
            Request = request;
        }
    }
}
