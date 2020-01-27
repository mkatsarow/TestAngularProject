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
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Main { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public string Icon { get; set; }
    }
}
