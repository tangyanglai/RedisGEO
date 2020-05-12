using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Json;
using Abp.UI;
using Castle.Core.Logging;
using Microsoft.Extensions.Configuration;

namespace RedisGEO.Core.Abp
{
    public class RedisGEOServer : IShouldInitialize, ISingletonDependency, IRedisGEOServer
    {
        public RedisGEOServer(GeoConfig geoConfig)
        {
            this.geoConfig = geoConfig;
        }

        public void Initialize()
        {
            IGeoServer = new GeoServer(geoConfig);
        }

        private readonly GeoConfig geoConfig;



        private IGeoServer IGeoServer;

        public async Task<long> GeoCountAsync(string Key)
        {
            return await IGeoServer.GeoCountAsync(Key);
        }

        public async Task<bool> ExistsAsync(string Key)
        {
            return await IGeoServer.ExistsAsync(Key);
        }
        public async Task<bool> GeoAddAsync(AddInput input)
        {
            return await IGeoServer.GeoAddAsync(input);
        }

        public async Task<long> GeoDeleteAsync(DeleteInput input)
        {
            return await IGeoServer.GeoDeleteAsync(input);
        }

        public async Task<long> GeoBatchDeleteAsync(string Key)
        {
            return await IGeoServer.GeoBatchDeleteAsync(Key);
        }
        public async Task<List<RadiusWithDistResult>> GeoRadiusWithDistAsync(RadiusWithDistInput pointInput)
        {
            return await IGeoServer.GeoRadiusWithDistAsync(pointInput);
        }



    }
}
