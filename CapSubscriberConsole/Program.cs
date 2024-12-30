using CapSubscriberConsole;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddCap(options =>
        {
            //option.UseInMemoryMessageQueue();
            //option.UseDashboard();
            //option.UseRabbitMQ("");

            options.UseInMemoryStorage(); // Replace with SQL Server if needed
            //options.UseRabbitMQ(option =>
            //{
            //    option.UserName = "guest";
            //    option.Password = "guest";
            //    option.HostName = "localhost";
            //});

            options.UseRedis(opt =>
            {
                opt.Configuration = new StackExchange.Redis.ConfigurationOptions
                {
                    SslHost = "localhost:6379",
                };
            });

            options.DefaultGroupName = "default";
        });

        services.AddTransient<ConsoleCAPSubscriber>();

    }).Build();

await host.RunAsync();
