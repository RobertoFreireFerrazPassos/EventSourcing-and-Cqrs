using MediatR;

namespace Kitchen.Application.Commands
{
    public class ReserveOrderCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }

        public ReserveOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
