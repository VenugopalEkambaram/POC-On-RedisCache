using System;
using System.Collections.Generic;

namespace RedisCachePOC
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var con = RedisConnectionFactory.GetConnection();
            var db = con.GetDatabase();

            Console.WriteLine("Saving random data in cache");  
            SaveBigData();

            Console.WriteLine("Reading data from cache");
            ReadData();  
  
            Console.ReadLine();  

            //string demo
            var inputStringData = "A little bit of string  data.";
            db.StringSet("StringData", inputStringData);
            string outputStringData = db.StringGet("StringData");
            Console.WriteLine(outputStringData);
            db.KeyDelete("StringData");

            //integer demo
            var inputIntData = 3855;
            db.StringSet("IntData", inputIntData);
            var outputIntData = (int) db.StringGet("IntData");
            Console.WriteLine(outputIntData);
            
            db.KeyDelete("IntData");

           // IRedisObjectStore<string> me = new RedisObjectStore<string>(db);
           // me.Save("Key1", "Val 1");
            //me.Save("Key1", new List<string> { "Hello 1", "Hello 2", "Hello 3" });
        }

        public static void ReadData()
        {
            var cache = RedisConnectionFactory.GetConnection().GetDatabase();
            var devicesCount = 100;
            for (var i = 0; i < devicesCount; i++)
            {
                var value = cache.StringGet(string.Format("Key:{0}", i));
                Console.WriteLine("Valor={0}", value);
            }
        }

        public static void SaveBigData()
        {
            var devicesCount = 100;
            var rnd = new Random();
            var cache = RedisConnectionFactory.GetConnection().GetDatabase();

            for (var i = 1; i < devicesCount; i++)
            {
                var value = rnd.Next(0, 10000);
                cache.StringSet(string.Format("Key:{0}", i), value);
            }
        }
    }
}