using MassTransit;
using Showcase.MassTransit;
using Showcase.MassTransit.Configurations;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.ConfigureLogs(builder.Configuration);

builder.Services.AddMassTransit(configure =>
{
    configure.SetKebabCaseEndpointNameFormatter();

    configure.AddConsumer<MessageConsumer>();

    configure.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration["RabbitMqMessageBroker:Host"], "/", h =>
        {
            h.Username(builder.Configuration["RabbitMqMessageBroker:Username"]);
            h.Password(builder.Configuration["RabbitMqMessageBroker:Password"]);
        });

        configurator.ConfigureEndpoints(context);
    });
});

builder.Services.AddHostedService<MessagePublisher>();

var host = builder.Build();
host.Run();