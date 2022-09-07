# dotnet-cache-aside
POC - Cache-Aside with Cassandra and Redis in .net core.


https://citizix.com/how-to-run-cassandra-4-with-docker-and-docker-compose/

> cqlsh -u cassandra -p cassandra

> CREATE KEYSPACE IF NOT EXISTS irispoc WITH replication = {'class':'SimpleStrategy','replication_factor':'1'};

> CREATE TABLE IF NOT EXISTS irispoc.adapterkey (   key varchar,   value varchar,   PRIMARY KEY (key)  ) ;

> select * from irispoc.adapterkey ;

> insert into irispoc.adapterkey (key, value) Values ('123456', '{"type":0,"id":"654321111"}');