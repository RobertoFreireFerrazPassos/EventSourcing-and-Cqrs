using MassTransit;
using Microsoft.EntityFrameworkCore;
using Receipt.Api.Infra.DataAccess;
using Receipt.Api.Infra.Events.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(bus =>
{
    bus.AddConsumer<StoreEventConsumer>();

    bus.UsingRabbitMq((context, busConfigurator) =>
    {
        busConfigurator.Host(builder.Configuration.GetConnectionString("RabbitMq"));

        busConfigurator.ReceiveEndpoint("StoreEvent", e =>
        {
            e.ConfigureConsumer<StoreEventConsumer>(context);
        });
    });
});

builder.Services.AddDbContext<ReceiptContext>(opt => opt.UseInMemoryDatabase("ReceiptDb"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
