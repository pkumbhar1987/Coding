using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisDemo
{
    [Serializable]
    public class Entities
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }
    }
}
