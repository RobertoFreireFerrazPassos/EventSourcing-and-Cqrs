using Kitchen.Domain.Dtos;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Enums;
using Kitchen.Domain.Events;
using Kitchen.Domain.Events.Entities;
using Kitchen.Domain.Repositories;
using Kitchen.Domain.Services;
using Newtonsoft.Json;

namespace Kitchen.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _eventStoreRepository;

        public OrderService(IOrderRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public OrderEntity CreateOrder(OrderCreatedCommand orderCreatedCommand)
        {
            var serializedData = JsonConvert.SerializeObject(orderCreatedCommand);

            var storedEvent = new StoredEvent(
                orderCreatedCommand.GetType().Name,
                Guid.NewGuid(),
                serializedData);

            var activeOrder = _eventStoreRepository.GetActiveOrder(
                        orderCreatedCommand.Table
                    );

            if (activeOrder is not null)
            {
                throw new Exception("Active order for table " + orderCreatedCommand.Table);
            }

            var orderEntity = new OrderEntity()
            {
                AggregateId = storedEvent.AggregateId,
                Table = orderCreatedCommand.Table,
                Status = OrderStatus.Active,
                Items = orderCreatedCommand.Items.Select(i => new ItemEntity()
                {
                    Name = i.Name,
                    Quantity = i.Quantity
                }).ToList()
            };

            var table = _eventStoreRepository.GetTablesByTableId(orderCreatedCommand.Table);

            table = table ?? new TableEntity()
            {
                Table = orderCreatedCommand.Table,
                CurrentAggregateId = storedEvent.AggregateId
            };            

            _eventStoreRepository.CreateOrder(storedEvent, table, orderEntity);

            return orderEntity;
        }

        public void GetOrder()
        {
            
        }
    }
}
