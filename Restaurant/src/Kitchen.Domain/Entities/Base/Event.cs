namespace Kitchen.Domain.Entities.Base
{
    public class Event
    {
        public string MessageType { get; set; }

        public DateTime Timestamp
        {
            get;
            private set;
        }

        public Guid AggregateId
        {
            get;
            protected set;
        }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }

    }    
}
