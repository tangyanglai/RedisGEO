using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedisGEO.Core.Abp
{
    public interface IRedisGEOServer
    {
        Task<bool> ExistsAsync(string Key);
        Task<long> GeoCountAsync(string Key);

        Task<bool> GeoAddAsync(AddInput input);

        Task<long> GeoDeleteAsync(DeleteInput input);

        Task<long> GeoBatchDeleteAsync(string Key);

        Task<List<RadiusWithDistResult>> GeoRadiusWithDistAsync(RadiusWithDistInput pointInput);
    }
}
