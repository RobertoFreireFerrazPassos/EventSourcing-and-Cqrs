using Kitchen.Domain.Repositories;
using Microsoft.Extensions.Hosting;

namespace Kitchen.EventOutbox
{
    public class EventOutboxBackgroundService : BackgroundService
	{
		private readonly IIntegrationEventOutboxRepository _integrationEventOutboxRepository;

		public EventOutboxBackgroundService(IIntegrationEventOutboxRepository integrationEventOutboxRepository)
		{
			_integrationEventOutboxRepository = integrationEventOutboxRepository;
		}

		protected async override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);

				try
				{
					var integrationEvents = await _integrationEventOutboxRepository.GetIntegrationEventsOutbox(stoppingToken);

					// TO DO: publish events

					_integrationEventOutboxRepository.DeleteIntegrationEventsOutbox(integrationEvents);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}
