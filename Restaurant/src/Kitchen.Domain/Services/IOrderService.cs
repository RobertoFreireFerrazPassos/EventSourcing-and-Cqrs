using Kitchen.Domain.Dtos;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Services
{
    public interface IOrderService
    {
        OrderEntity CreateOrder(OrderCreatedCommand request);
        OrderEntity GetOrder(int table);
        bool ReserveOrder(OrderReservedCommand orderReservedCommand);
    }
}
