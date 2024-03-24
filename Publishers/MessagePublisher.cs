using MassTransit;
using Showcase.MassTransit.DTOs;

namespace Showcase.MassTransit
{
    internal class MessagePublisher(IBus bus) : BackgroundService
    {
        private const int TimeToDelayInMilliseconds = 5000;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (bus is null) continue;

                var messageDto = new MessageDto($"My value. Current time {DateTime.UtcNow}");

                await bus.Publish(messageDto, stoppingToken);

                await Task.Delay(TimeToDelayInMilliseconds, stoppingToken);
            }
        }
    }
}