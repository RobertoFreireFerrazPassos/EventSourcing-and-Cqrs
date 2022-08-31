using Events.Contracts;
using MassTransit;
using Receipt.Api.Entities;
using Receipt.Api.Infra.DataAccess;

namespace Receipt.Api.Infra.Events.Consumers
{
    public class StoreEventConsumer : IConsumer<StoredEvent>
    {
        private readonly ReceiptContext _context;

        public StoreEventConsumer(ReceiptContext context)
        {
            _context = context;
        }

        public Task Consume(ConsumeContext<StoredEvent> storedEvent)
        {
            var entity = new StoredEventEntity()
            {
                Id = storedEvent.Message.Id,
                MessageType = storedEvent.Message.MessageType,
                Timestamp = storedEvent.Message.Timestamp,
                AggregateId = storedEvent.Message.AggregateId,
                Data = storedEvent.Message.Data
            };

            _context.Events.Add(entity);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
