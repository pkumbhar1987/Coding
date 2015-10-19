using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Frameworks.Infrastructure;
using Tavisca.Frameworks.Redis;

namespace RedisDemo
{
    public class ModuleInitializer : IContainerInitializer
    {
        public void Initialize(IDependencyContainer container)
        {
            container                
                .RegisterType<IMethods,Managercs>()
                .RegisterType<IRedisConnectorFactory, RedisConnectorFactory>()
                ;
        }
    }
}
