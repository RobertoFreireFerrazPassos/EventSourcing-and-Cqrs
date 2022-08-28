using Kitchen.Domain.Entities;
using Kitchen.Domain.Events;
using Kitchen.Domain.Producers;
using Kitchen.Domain.Repositories;
using Microsoft.Extensions.Hosting;

namespace Kitchen.EventOutbox
{
    public class EventOutboxBackgroundService : BackgroundService
	{
		private readonly IIntegrationEventOutboxRepository _integrationEventOutboxRepository;

		private readonly IOrderEventProducer _orderEventProducer;

		public EventOutboxBackgroundService(
			IIntegrationEventOutboxRepository integrationEventOutboxRepository,
			IOrderEventProducer orderEventProducer)
		{
			_integrationEventOutboxRepository = integrationEventOutboxRepository;
			_orderEventProducer = orderEventProducer;
		}

		protected async override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);

				try
				{
					var integrationEvents = await _integrationEventOutboxRepository.GetIntegrationEventsOutbox(stoppingToken);
					var eventsToBeDeleted = new List<IntegrationEventOutbox>();

					foreach (var integrationEvent in integrationEvents)
                    {
						var storedEvent = new StoredEvent()
						{
							Id = integrationEvent.Event.Id,
							MessageType = integrationEvent.Event.MessageType,
							Timestamp = integrationEvent.Event.Timestamp,
							AggregateId = integrationEvent.Event.AggregateId,
							Data = integrationEvent.Event.Data
						};

						var wasSent = _orderEventProducer.Publish(storedEvent).Result;

						if (wasSent)
                        {
							eventsToBeDeleted.Add(integrationEvent);
						}
					}					

					_integrationEventOutboxRepository.DeleteIntegrationEventsOutbox(eventsToBeDeleted);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}
