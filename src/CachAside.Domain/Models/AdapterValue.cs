using CacheAside.Domain.Enums;

namespace CacheAside.Domain.Models
{
    public class AdapterValue
    {
        public AdapterValue(ValueTypeEnum type, string id)
        {
            Type = type;
            Id = id;

        }
        public ValueTypeEnum Type { get; set; }
        public string Id { get; set; }
    }
}
