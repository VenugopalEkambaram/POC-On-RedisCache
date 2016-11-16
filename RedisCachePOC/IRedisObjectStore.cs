using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCachePOC
{
    public interface IRedisObjectStore<T>
    {
        /// <summary>
        /// Get an object stored in redis by key
        /// </summary>
        /// <param name="key">The key used to stroe object</param>
        T Get(string key);

        /// <summary>
        /// Save an object in redis
        /// </summary>
        /// <param name="key">The key to stroe object against</param>
        /// <param name="obj">The object to store</param>
        void Save(string key, T obj);

        /// <summary>
        /// Delete an object from redis using a key
        /// </summary>
        /// <param name="key">The key the object is stored using</param>
        void Delete(string key);
    }
}
