using Kitchen.Domain.Dtos;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Enums;
using Kitchen.Domain.Repositories;
using Kitchen.Domain.Services;
using Newtonsoft.Json;

namespace Kitchen.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;      

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;          
        }

        public async Task<OrderEntity> CreateOrder(OrderCreatedCommand orderCreatedCommand)
        {
            var table = await _orderRepository.GetTable(orderCreatedCommand.Table);

            if (table is null)
            {
                throw new Exception("There is not table " + orderCreatedCommand.Table);
            }

            var serializedData = JsonConvert.SerializeObject(orderCreatedCommand);

            var storedEvent = new StoredEventEntity(
                orderCreatedCommand.GetType().Name,
                Guid.NewGuid(),
                serializedData);

            var activeOrder = await _orderRepository.GetActiveOrder(orderCreatedCommand.Table);

            if (activeOrder is not null)
            {
                throw new Exception("There is still active order(s) for table " + orderCreatedCommand.Table);
            }

            var orderEntity = new OrderEntity()
            {
                AggregateId = storedEvent.AggregateId,
                Table = orderCreatedCommand.Table,
                Status = OrderStatus.Active,
                Items = orderCreatedCommand.Items.Select(i => new OrderItemEntity()
                {
                    MenuItem = new MenuItemEntity()
                    {
                        Name = i.Name
                    },                    
                    Quantity = i.Quantity
                }).ToList()
            };

            table.CurrentAggregateId = storedEvent.AggregateId;

            _orderRepository.CreateOrder(storedEvent, table, orderEntity);

            return orderEntity;
        }

        public async Task<OrderEntity> GetOrder(int table)
        {
            var tableEntity = await _orderRepository.GetTable(table);

            if (tableEntity is null)
            {
                throw new Exception("There is not table " + table);
            }

            var order = await _orderRepository.GetOrder(table, tableEntity.CurrentAggregateId);

            if (order is null)
            {
                throw new Exception("There is not order for this table " + table);
            }

            return order;
        }

        public async Task<bool> ReserveOrder(OrderReservedCommand orderReservedCommand)
        {
            var order = await _orderRepository.GetOrder(orderReservedCommand.OrderId);

            if (order is null)
            {
                throw new Exception("Order " + orderReservedCommand.OrderId + " doesn't exist.");
            }

            if (order.Status != OrderStatus.Active)
            {
                throw new Exception("Order " + orderReservedCommand.OrderId + " with status " + order.Status + " cannot be reserved");
            }

            order.Status = OrderStatus.Reserved;

            var serializedData = JsonConvert.SerializeObject(orderReservedCommand);

            var storedEvent = new StoredEventEntity(
                orderReservedCommand.GetType().Name,
                order.AggregateId,
                serializedData);

            await _orderRepository.UpdateOrder(storedEvent, order);

            return true;
        }
    }
}
