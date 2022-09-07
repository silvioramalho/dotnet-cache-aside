using Newtonsoft.Json;

namespace CacheAside.Domain.Models
{
    public class AdapterKey
    {
        public AdapterKey()
        {

        }
        
        public AdapterKey(string key)
        {
            Key = key;
        }

        public AdapterKey(string key, AdapterValue value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public AdapterValue Value { get; set; }
    }
}