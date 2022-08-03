namespace Kitchen.Domain.Events.Base
{
    public class Event : Message
    {
        public DateTime Timestamp
        {
            get;
            private set;
        }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }

    }    
}
