using CSRedis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisGEO.Core
{
    public class GeoServer : IGeoServer
    {
        private CSRedisClient client;

        public GeoServer(GeoConfig geoConfig)
        {
            this.client = new CSRedisClient(geoConfig.ConnectionString);
        }

        public async Task<bool> ExistsAsync(string Key)
        {
            return await client.ExistsAsync(Key);
        }
        public async Task<long> GeoCountAsync(string Key)
        {
            return await client.ZCardAsync(Key);
        }
        public async Task<bool> GeoAddAsync(AddInput input)
        {
            return await client.GeoAddAsync(input.Key, input.Longitude, input.Latitude, input.Name);
        }

        public async Task<long> GeoDeleteAsync(DeleteInput input)
        {
            return await client.ZRemAsync(input.Key, input.Name);
        }

        public async Task<long> GeoBatchDeleteAsync(string Key)
        {
            return await client.DelAsync(Key);
        }

        public async Task<List<RadiusWithDistResult>> GeoRadiusWithDistAsync(RadiusWithDistInput pointInput)
        {
            var values = await client.GeoRadiusWithDistAsync(pointInput.Key, pointInput.Longitude, pointInput.Latitude,
                pointInput.Radius, pointInput.Unit, pointInput.Count, pointInput.GeoOrderBy);
            var rwds = from v in values.ToList()
                       select new RadiusWithDistResult()
                       {
                           Name = v.member,
                           Dist = v.dist
                       };
            return rwds.ToList();
        }


    }
}
