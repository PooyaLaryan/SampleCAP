using Microsoft.Extensions.Options;
using Savorboard.CAP.InMemoryMessageQueue;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddCap(option =>
{
    //option.UseInMemoryMessageQueue();
    //option.UseDashboard();
    //option.UseRabbitMQ("");

    option.UseInMemoryStorage(); // Replace with SQL Server if needed
    //option.UseRabbitMQ(option =>
    //{
    //    option.UserName = "guest";
    //    option.Password = "guest";
    //    option.HostName = "localhost";
    //});

    option.UseRedis(opt =>
    {
        opt.Configuration = new StackExchange.Redis.ConfigurationOptions
        {
            SslHost = "localhost:6379",
        };
    });

    option.DefaultGroupName = "default";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
