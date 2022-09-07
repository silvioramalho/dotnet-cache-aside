using CacheAside.Domain.Models;
using Cassandra;
using Cassandra.Mapping;
using Newtonsoft.Json;

namespace CacheAside.Repository.Cassandra
{
    public class AdapterKeyRepository : IPersistence
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;
        private const string TABLE_NAME = "irispoc.adapterkey";

        public AdapterKeyRepository(
            ICassandraServiceRepository serviceRepository) {
            _session = serviceRepository.GetSession();
            _mapper = new Mapper(_session);
        }

        public async Task AddAsync(KeyValueItem keyValueItem, CancellationToken cancellationToken)
        {
            await _mapper.ExecuteAsync($"Insert into {TABLE_NAME} (key, value) Values (?, ?)", keyValueItem.Key, keyValueItem.Value);
        }

        public async Task<IEnumerable<KeyValueItem>> GetAsync(string key, CancellationToken cancellationToken)
        {
            return await _mapper.FetchAsync<KeyValueItem>($"Select * from {TABLE_NAME} where key = ?", key);
        }
    }
}
