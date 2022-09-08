using CacheAside.Application.Extensions;
using CacheAside.ConsoleRunner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args).Build();

IConfiguration configuration = host.Services.GetRequiredService<IConfiguration>();


var services = new ServiceCollection();
services.AddLogging(configure => configure.AddConsole());
services.AddApplicationServices(configuration);
services.AddTransient<ConsoleApp>();

services.BuildServiceProvider()
    .GetService<ConsoleApp>()!.Run();
