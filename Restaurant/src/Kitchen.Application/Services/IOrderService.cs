using Kitchen.Application.Commands;

namespace Kitchen.Application.Services
{
    public interface IOrderService
    {
        void CreateOrder(CreateOrderCommand request);
        void GetOrder();
    }
}
