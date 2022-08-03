namespace Kitchen.Domain.Events.Base
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
