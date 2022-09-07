using CacheAside.Domain.Models;
using StackExchange.Redis;

namespace CacheAside.Repository.Redis
{
    public class AdapterKeyCache : ICache
    {
        private readonly IConnectionMultiplexer _connection;

        public AdapterKeyCache(IConnectionMultiplexer connection)
        {
            _connection = connection;
        }

        public async Task<bool> AddAsync(KeyValueItem keyValueItem, CancellationToken cancellationToken)
        {
            var cache = _connection.GetDatabase();
            return await cache.StringSetAsync(keyValueItem.Key, keyValueItem.Value);
        }

        public async Task<KeyValueItem> GetAsync(string key, CancellationToken cancellationToken)
        {
            var keyValue = new KeyValueItem(key);
            var cache = _connection.GetDatabase();
            var stringValue = await cache.StringGetAsync(key, CommandFlags.None);
            if (stringValue.HasValue)
            {
                keyValue.Value = stringValue;
            }

            return await Task.FromResult(keyValue);
        }
    }
}
