using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Runtime.Caching.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisGEO.Core.Abp
{
    public static class ConfigurationExtensions
    {
        public static void UseGeoRedis(this IAbpStartupConfiguration Configuration, Action<GeoConfig> optionsAction)
        {
            IIocManager iocManager = Configuration.IocManager;
            optionsAction(iocManager.Resolve<GeoConfig>());
        }
    }
}
