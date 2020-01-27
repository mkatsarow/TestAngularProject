using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngularP.Models
{
    public class Main
    {
        [JsonProperty]
        public double Temp { get; set; }
        [JsonProperty]
        public double Feels_like { get; set; }
        [JsonProperty]
        public double Temp_min { get; set; }
        [JsonProperty]
        public double Temp_max { get; set; }
        [JsonProperty]
        public double Pressure { get; set; }
        [JsonProperty]
        public int Humidity { get; set; }

    }
}
