using CacheAside.Domain.Models;
using Newtonsoft.Json;

namespace CacheAside.Domain.Extensions
{
    public static class KeyValueItemExtensions
    {
        public static AdapterKey ToAdapterKey(this KeyValueItem keyValueItem)
        {
            if (keyValueItem == null) return null;
            if(keyValueItem.Value == null) return new AdapterKey(keyValueItem.Key);            
            return new AdapterKey(keyValueItem.Key, JsonConvert.DeserializeObject<AdapterValue>(keyValueItem.Value.ToString()));
        }

        public static IEnumerable<AdapterKey> ToAdapterKeys(this IEnumerable<KeyValueItem> keyValueList)
            => keyValueList.Select(item => new AdapterKey(item.Key, JsonConvert.DeserializeObject<AdapterValue>(item.Value)));
    }
}
