using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisDemo
{
    public class SaveToken
    {
        public Guid TokenId { get; set; }
        public Guid SessionId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
