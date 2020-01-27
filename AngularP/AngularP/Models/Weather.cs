using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularP.Models;
using Newtonsoft.Json;

namespace AngularP
{
    public class Weather
    {
        [JsonProperty("coord")]
        public Coord Coordinates { get; set; }
        [JsonProperty]
        public string Main { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public string Base { get; set; }
    }
}
