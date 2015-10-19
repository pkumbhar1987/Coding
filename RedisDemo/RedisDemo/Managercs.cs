using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Frameworks.Redis;

namespace RedisDemo
{
    public class Managercs : IMethods
    {
        public IRedisConnectorFactory Factory { get; set; }

        public Managercs(IRedisConnectorFactory redisClientFactory)
        {
            this.Factory = redisClientFactory;
        }

        public void SaveObject(Object obj)
        {
            var key = new Keys("test", "1");
            
            using (var client=this.Factory.GetNativeClient())
            {
                var objectvalue = new Translator();
                client.LPush(key,objectvalue.ObjectToByteArray(obj));
            }
        }

        public object RetriveObject()
        {
            var key = new Keys("T.F.L", "MessageLog");

            using (var client = this.Factory.GetNativeClient())
            {
                var objectvalue = new Translator();
                var byteValue= client.RPop(key);
                return objectvalue.ByteArrayToObject(byteValue);
            }            
        }
    }
}
