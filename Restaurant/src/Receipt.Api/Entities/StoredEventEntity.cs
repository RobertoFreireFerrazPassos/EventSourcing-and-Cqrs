namespace Receipt.Api.Entities
{
    public class StoredEventEntity
    {
        public Guid Id { get; set; }

        public string MessageType { get; set; }

        public DateTime Timestamp { get; set; }

        public Guid AggregateId { get; set; }

        public string Data { get; set; }
    }
}
