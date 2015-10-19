using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;

namespace RedisDemo
{
    public class PooledRedisClientInstanceManager
    {
        private static PooledRedisClientManager _redisClientManager = null;

        public static string[] Hosts = {"Delhi:6379"};

        public static IRedisClient GetRedisClient()
        {
            if (_redisClientManager == null) _redisClientManager = new PooledRedisClientManager(10, 1500, Hosts);
            return _redisClientManager.GetClient();
        }

        private PooledRedisClientInstanceManager()
        {
        }
    }
}
