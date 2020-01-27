using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngularP.Models
{
    public class Coord
    {
        [JsonProperty]
        public long Lon { get; set; }
        [JsonProperty]
        public long Lat { get; set; }
    }
}
