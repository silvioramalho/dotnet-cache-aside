using CacheAside.Domain.Enums;
using CacheAside.Domain.Models;

namespace CacheAside.Application
{
    public interface IAdapterKeyService
    {
        Task<string> GetRelatedKey(string key, ValueTypeEnum type, CancellationToken cancellationToken);

        Task AddCacheAsync(AdapterKey adapterKey, CancellationToken cancellationToken);

        Task AddDbAsync(AdapterKey adapterKey, CancellationToken cancellationToken);

        Task<AdapterKey> GetCacheAsync(string key, CancellationToken cancellationToken);

        Task<IEnumerable<AdapterKey>> GetDbListAsync(string key, CancellationToken cancellationToken);

    }
}