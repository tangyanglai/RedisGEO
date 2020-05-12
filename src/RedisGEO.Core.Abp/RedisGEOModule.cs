using Abp.Modules;
using Abp.Reflection.Extensions;
using System;

namespace RedisGEO.Core.Abp
{
    public class RedisGEOModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<GeoConfig>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RedisGEOModule).GetAssembly());
        }

        public override void PostInitialize()
        {
        }
    }
}
