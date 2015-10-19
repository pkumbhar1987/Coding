using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisDemo
{
    public class SaveAdministratorSession
    {
        public Guid SessionId { get; set; }
        public string AuthenticationToken { get; set; }
        public bool IsValid { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
