using CacheAside.Domain.Models;

namespace CacheAside.Repository
{
    public interface ICache
    {
        Task<bool> AddAsync(KeyValueItem keyValueItem, CancellationToken cancellationToken);

        Task<KeyValueItem> GetAsync(string key, CancellationToken cancellationToken);
    }
}
