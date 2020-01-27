using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngularP.Models
{
    public class Sys
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public int Type { get; set; }
        [JsonProperty]
        public string Country { get; set; }
        [JsonProperty]
        public int Sunrise { get; set; }
        [JsonProperty]
        public int Sunset { get; set; }
    }
}
