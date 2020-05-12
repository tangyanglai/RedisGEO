using CSRedis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisGEO.Core
{
    public class RadiusWithDistInput
    {
        public string Key { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public decimal Radius { get; set; }
        public GeoUnit Unit { get; set; }
        public long? Count { get; set; }
        public GeoOrderBy? GeoOrderBy { get; set; }
    }
    public class RadiusWithDistResult
    {
        public string Name { get; set; }
        public decimal Dist { get; set; }
    }
}
