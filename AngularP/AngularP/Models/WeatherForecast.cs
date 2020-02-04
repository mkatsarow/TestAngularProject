using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngularP.Models
{
    public class WeatherForecast
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Base { get; set; }
        [JsonProperty]
        public string TimeZone { get; set; }
        [JsonProperty]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [JsonProperty]
        public string Cod { get; set; }
        [JsonProperty]
        [Required]
        public Main Main { get; set; }
        [JsonProperty("weather")]
        public ICollection<Weather> WeatherCollection { get; set; }
        [JsonProperty]
        [Required]
        public int Visibility { get; set; }
        [JsonProperty]
        [Required]
        public Wind Wind { get; set; }
        [JsonProperty]
        public Clouds Clouds { get; set; }


        [JsonProperty("dt")]
        [Required]
        public string DateTime { get; set; }
        [JsonProperty]
        public Sys Sys { get; set; }
    }
}
