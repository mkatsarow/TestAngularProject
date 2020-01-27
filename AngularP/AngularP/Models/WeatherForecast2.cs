using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngularP.Models
{
    public class WeatherForecast2
    {
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string Base { get; set; }
        [JsonProperty]
        public string TimeZone { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Cod { get; set; }
        [JsonProperty]
        public Main Main { get; set; }
        [JsonProperty]
        public ICollection<Weather> Weather { get; set; }
        [JsonProperty]
        public int Visibility { get; set; }
        [JsonProperty]
        public Wind Wind { get; set; }
    }
}
