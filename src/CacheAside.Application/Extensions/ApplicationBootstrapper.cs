using CacheAside.Application.Services;
using CacheAside.Repository;
using CacheAside.Repository.Cassandra;
using CacheAside.Repository.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CacheAside.Application.Extensions
{
    public static class ApplicationBootstrapper
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddSingleton<IConnectionMultiplexer>(i => ConnectionMultiplexer.Connect(configuration["redisConnectionString"]))
                .AddSingleton<ICache, AdapterKeyCache>()
                .AddSingleton<ICassandraServiceRepository, CassandraServiceRepository>()
                .AddSingleton<IPersistence, AdapterKeyRepository>()
                .AddScoped< IAdapterKeyService , AdapterKeyService>();
        }
    }
}
