using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisCachePOC
{
    class RedisConnectionFactory
    {
        private static readonly Lazy<ConnectionMultiplexer> Connection;

        static RedisConnectionFactory()
        {
            //var connectionString = "";
                //System.Configuration.ConfigurationManager.AppSettings["RedisConnection"].ToString();
            //var options = ConfigurationOptions.Parse(connectionString);
            Connection = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect("localhost")
                );
        }

        public static ConnectionMultiplexer GetConnection()
        {
          return  Connection.Value;
        }
    }
}

