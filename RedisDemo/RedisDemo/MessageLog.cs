using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisDemo
{
    [Serializable]
    public class MessageLog
    {
        public string ServiceUrl { get; set; }
        public string ServiceName { get; set; }
        public string Action { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public TimeSpan TimeElapsed { get; set; }
        public Dictionary<string, string> AdditionalData { get; set; }
    }
}
