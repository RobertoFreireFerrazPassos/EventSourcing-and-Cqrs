using Kitchen.Domain.Entities;
using Kitchen.Domain.Producers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Kitchen.Events.Producers
{
    public class OrderEventProducer : IOrderEventProducer
    {
        private readonly IServiceProvider _serviceProvider;

        public OrderEventProducer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

    public async Task<bool> Publish(StoredEventEntity storedEventEvent)
        {
            try
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    var publisher = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();

                    await publisher.Publish(storedEventEvent);
                }
                
                return true;
            }
            catch
            {
                return false;
            }            
        }
    }
}
