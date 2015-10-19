using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisDemo
{
    public class SaveSessionEntities 
    {
        public Guid SessionId { get; set; }

        public Guid AccountId { get; set; }

        public DateTime ExpiryTimestamp { get; set; }

        public bool IsValid { get; set; }

        public bool IsSingleUse { get; set; }

        public int SessionLifeTime { get; set; }

        public bool IsSlidingWindow { get; set; }

        public Guid ApplcationId { get; set; }

        public int ValidationCount { get; set; }

        public int PresentValidation { get; set; }

        public DateTime CreationTimestamp { get; set; }

        public DateTime LastAccessedTimestamp { get; set; }
    }
}
