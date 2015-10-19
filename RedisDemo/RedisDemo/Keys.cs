using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Frameworks.Redis;

namespace RedisDemo
{
    internal class Keys : Key
    {
        public Keys(string prefix, string keyValue)
            : base(prefix)
        {
            this.KeyValue = keyValue.ToString();
        }

        public string KeyValue { get; private set; }

        protected override string GetKey()
        {
            return this.KeyValue;
        }
    }
}
