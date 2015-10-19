using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisDemo
{
    public interface IMethods
    {
        void SaveObject(Object obj);

        object RetriveObject();
    }
}
