using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using ServiceStack.Redis;
using Tavisca.Frameworks.Infrastructure;

namespace RedisDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {

            string host = "10.2.9.104";
            string elementKey = "testKeyRedis";
            string message = "";

            using (RedisClient redisClient = new RedisClient(host, 6379))
            {
                

                redisClient.FlushAll();
                redisClient.Set("test", "test12345");
                byte[] s = redisClient.Get("test");

            }
        }
    }
}

//            //redisClient.FlushAll();


//                //if (redisClient.Get<string>(elementKey) == null)
//                //{
//                    // adding delay to see the difference
//                    //Thread.Sleep(5000);
//                    // save value in cache

//                    byte[] lpushvalue = { 1, 2, 3, 6 ,5,6,7,7, };
//                    byte[] lpushvalue1 = { 1 };
//                    byte[] lpushvalue2 = { 1, 2};
//                    byte[] lpushvalue3 = { 1, 2, 3};

//                    //redisClient.ConnectTimeout = 5;
//                    //redisClient.IdleTimeOutSecs = 30;

//                    //var length = redisClient.LLen("1");


//                    Entities obj=new Entities();

//                obj.FirstName = "Pramod";
//                obj.LastName = "Kumbhar";
//                obj.Address1 = "test address 1";
//                obj.Address2 = "test address 2";


//                var redismanager = ObjectFactory.Build<IMethods>();

//                //redismanager.SaveObject(obj);

//                var retrivedvalue = redismanager.RetriveObject();

//                //Translator translator=new Translator();

//                //var bytearray= translator.ObjectToByteArray(obj);

//                //redisClient.LPush("test", bytearray);

//                //var a = redisClient.LPop("test");

//                //var objectvalue= translator.ByteArrayToObject(a);

                    
//                    //redisClient.LPush("1", lpushvalue1);
//                    //redisClient.LPush("1", lpushvalue2);
//                    //redisClient.LPush("1", lpushvalue3);
//                    //redisClient.LPush("1", lpushvalue);

//                    ////redisClient.LSet("1", 0, lpushvalue);
//                    ////redisClient.LSet("1", 1, lpushvalue1);
//                    ////redisClient.LSet("1", 2, lpushvalue2);
//                    ////redisClient.LSet("1", 3, lpushvalue3);


//                    //var val = redisClient.RPop("1");
//                    //var val1 = redisClient.RPop("1");
//                    //var val2 = redisClient.RPop("1");
//                    //var val3 = redisClient.RPop("1");
//                    //var val4 = redisClient.RPop("1");

//                    //var length1 = redisClient.LLen("1");

//                    //List<string> test=new List<string>(){"1","2","3"};

//                    //redisClient.Set(elementKey, test,DateTime.Now.AddSeconds(30));

//                    //var obj=redisClient.Get<List<string>>(elementKey);

//                }
//                // get value from the cache by key
//                //message = "Item value is: " + redisClient.Get<string>(elementKey);

//                //redisClient.Remove(elementKey);

//                //var s= redisClient.Get(elementKey);

//               // Console.WriteLine(message);
//            }

//            //Guid sessionId = Guid.NewGuid();

//            //Console.Write(sessionId.ToString());

//            //RedisCache.SaveSession(sessionId, new Guid(), DateTime.Now.AddMinutes(2), true, false, 60, true, new Guid(), 0, 0);

//            //RedisCache.SaveAdministratorSession(sessionId, "YTcwODdmY2ItMjllMC00ZDFlLWFjZGItMDAwMDAyMjE1Yzc2", true,
//            //                                    DateTime.Now.AddMinutes(2));



//            //var nv = new NameValueCollection
//            //    {
//            //        {"UserIDType", "DealerID,DealerID"},
//            //        {"SSOSourceApplication", "192.168.1.171,192.168.1.171"},
//            //        {"SSOHostIP", "DealerID,DealerID"},
//            //        {"Type", "UserAuth,UserAuth"}
//            //    };

//            //RedisCache.SaveTokens(sessionId, nv);

//            //Console.ReadKey();

            
//        //}
//    }
//}
