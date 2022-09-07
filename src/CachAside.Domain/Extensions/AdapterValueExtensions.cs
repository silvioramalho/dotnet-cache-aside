using CacheAside.Domain.Models;
using Newtonsoft.Json;

namespace CacheAside.Domain.Extensions
{
    public static class AdapterValueExtensions
    {
        public static KeyValueItem ToKeyValueItem(this AdapterKey adapterKey)
            => new KeyValueItem(adapterKey.Key, JsonConvert.SerializeObject(adapterKey.Value));
    }
}
