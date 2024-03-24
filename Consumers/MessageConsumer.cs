using MassTransit;
using Showcase.MassTransit.DTOs;

namespace Showcase.MassTransit
{
    internal class MessageConsumer(Serilog.ILogger logger) : IConsumer<MessageDto>
    {
        public Task Consume(ConsumeContext<MessageDto> context)
        {
            logger.Information("{Consumer} Received a new message: {Message}", nameof(MessageConsumer), context.Message.Value);
            return Task.CompletedTask;
        }
    }
}