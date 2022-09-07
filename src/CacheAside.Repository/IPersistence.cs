using CacheAside.Domain.Models;

namespace CacheAside.Repository
{
    public interface IPersistence
    {
        Task AddAsync(KeyValueItem keyValueItem, CancellationToken cancellationToken);

        Task<IEnumerable<KeyValueItem>> GetAsync(string key, CancellationToken cancellationToken);
    }
}
