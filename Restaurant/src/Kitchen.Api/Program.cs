using Kitchen.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

/*
 * To fix bug: InvalidCastException: Cannot write DateTime with Kind=Local to PostgreSQL type 'timestamp with time zone', only UTC is supported.
*/
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.RegisterServices(builder.Configuration);
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
