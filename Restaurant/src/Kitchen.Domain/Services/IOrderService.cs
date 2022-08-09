using Kitchen.Domain.Dtos;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Services
{
    public interface IOrderService
    {
        OrderEntity CreateOrder(OrderCreatedCommand request);
        void GetOrder();
        bool ReserveOrder(OrderReservedCommand orderReservedCommand);
    }
}
