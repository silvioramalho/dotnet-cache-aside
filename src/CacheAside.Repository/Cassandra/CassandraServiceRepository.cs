using Cassandra;
using Microsoft.Extensions.Configuration;

namespace CacheAside.Repository.Cassandra
{
    public class CassandraServiceRepository: ICassandraServiceRepository
    {
        private readonly Cluster _cluster;
        private readonly ISession _session;
        private readonly IConfiguration _configuration;

        public CassandraServiceRepository(
            IConfiguration configuration)
        {
            _configuration = configuration;
            if (_cluster == null)
            {
                _cluster = Connect();
                _session = _cluster.Connect(_configuration["CassandraKeyspace"]);
            }
            else if (_session == null)
            {
                _session = _cluster.Connect(_configuration["CassandraKeyspace"]);
            }
        }

        public ISession GetSession() => _session;

        private Cluster Connect()
        {
            string user = _configuration["CassandraUsername"];
            string pwd = _configuration["CassandraPassword"];
            int port = int.Parse(_configuration["CassandraPort"]);
            string[] nodes = _configuration["CassandraHosts"].Split(',');

            QueryOptions queryOptions = new QueryOptions()
                .SetConsistencyLevel(ConsistencyLevel.One);

            Cluster cluster = Cluster.Builder()
                .AddContactPoints(nodes)
                .WithPort(port)
                .WithCredentials(user, pwd)
                .WithQueryOptions(queryOptions)
                .Build();

            return cluster;
        }
    }
}
