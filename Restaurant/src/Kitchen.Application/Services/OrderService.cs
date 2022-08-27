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

        public OrderEntity CreateOrder(OrderCreatedCommand orderCreatedCommand)
        {
            var table = _orderRepository.GetTable(orderCreatedCommand.Table).Result;

            if (table is null)
            {
                throw new Exception("There is not table " + orderCreatedCommand.Table);
            }

            var serializedData = JsonConvert.SerializeObject(orderCreatedCommand);

            var storedEvent = new StoredEventEntity(
                orderCreatedCommand.GetType().Name,
                Guid.NewGuid(),
                serializedData);

            var activeOrder = _orderRepository.GetActiveOrder(
                        orderCreatedCommand.Table
                    ).Result;

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

        public OrderEntity GetOrder(int table)
        {
            var tableEntity = _orderRepository.GetTable(table).Result;

            if (tableEntity is null)
            {
                throw new Exception("There is not table " + table);
            }

            var order = _orderRepository.GetOrder(table, tableEntity.CurrentAggregateId).Result;

            if (order is null)
            {
                throw new Exception("There is not order for this table " + table);
            }

            return order;
        }

        public bool ReserveOrder(OrderReservedCommand orderReservedCommand)
        {

            var order = _orderRepository.GetOrder(orderReservedCommand.OrderId).Result;

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

            _orderRepository.UpdateOrder(storedEvent, order);

            return true;
        }
    }
}
