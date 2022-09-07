using Cassandra;

namespace CacheAside.Repository
{
    public interface ICassandraServiceRepository
    {
        ISession GetSession();
    }
}
