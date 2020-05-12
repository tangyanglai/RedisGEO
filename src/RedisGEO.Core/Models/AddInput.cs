using System;
using System.Collections.Generic;
using System.Text;

namespace  RedisGEO.Core
{
    public class AddInput
    {
        public string Key { get; set; }

        public string Name { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

    }
}
