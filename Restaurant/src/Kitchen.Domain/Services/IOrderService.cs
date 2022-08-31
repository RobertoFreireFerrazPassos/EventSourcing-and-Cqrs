using Kitchen.Domain.Dtos;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Services
{
    public interface IOrderService
    {
        Task<OrderEntity> CreateOrder(OrderCreatedCommand request);

        Task<OrderEntity> GetOrder(int table);
        Task<bool> ReserveOrder(OrderReservedCommand orderReservedCommand);
    }
}
