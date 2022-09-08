using CacheAside.Domain.Extensions;
using CacheAside.Domain.Enums;
using CacheAside.Domain.Models;
using CacheAside.Repository;
using CacheAside.Application.Providers;

namespace CacheAside.Application.Services
{
    public class AdapterKeyService : IAdapterKeyService
    {
        private readonly ICache _cache;
        private readonly IPersistence _db;

        public AdapterKeyService(ICache cache,
            IPersistence db)
        {
            _cache = cache;
            _db = db;
        }

        public async Task<string> GetRelatedKey(string key, ValueTypeEnum type, CancellationToken cancellationToken)
        {

            var adapterKey = await GetCacheAsync(key.Add9Digit(), cancellationToken);
            if (adapterKey.Value == null)
            {
                AdapterKey? dbValue = (await GetDbListAsync(key.Add9Digit(), cancellationToken)).FirstOrDefault();
                if (dbValue == null)
                {
                    dbValue = new AdapterKey(key.Add9Digit());
                    dbValue.Value = new AdapterValue(type, key);
                    await AddCacheAsync(dbValue, cancellationToken);
                    await AddDbAsync(dbValue, cancellationToken);
                }
                else
                {
                    await AddCacheAsync(dbValue, cancellationToken);
                }
                return dbValue.Value.Id;
            }
            else
            {
                return adapterKey.Value.Id;
            }
        }

        public async Task AddCacheAsync(AdapterKey adapterKey, CancellationToken cancellationToken)
        {
            if (adapterKey == null)
                return;

            await _cache.AddAsync(adapterKey.ToKeyValueItem(), cancellationToken);
        }

        public async Task AddDbAsync(AdapterKey adapterKey, CancellationToken cancellationToken)
        {
            if (adapterKey == null)
                return;

            await _db.AddAsync(adapterKey.ToKeyValueItem(), cancellationToken);
        }

        public async Task<AdapterKey> GetCacheAsync(string key, CancellationToken cancellationToken)
        {
            var keyValueItem  = await _cache.GetAsync(key, cancellationToken);
            if (keyValueItem == null)
                return null;

            return keyValueItem.ToAdapterKey();
        }

        public async Task<IEnumerable<AdapterKey>> GetDbListAsync(string key, CancellationToken cancellationToken)
        {
            var keyValueList = await _db.GetAsync(key, cancellationToken);
            return keyValueList.ToAdapterKeys();
        }
    }
}
