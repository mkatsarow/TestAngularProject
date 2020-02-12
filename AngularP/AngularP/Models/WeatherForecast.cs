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
        //{"coord":{"lon":23.32,"lat":42.7},"weather":[{"id":801,"main":"Clouds","description":"few clouds","icon":"02n"}],"base":"stations","main":{"temp":275.23,"feels_like":271.49,"temp_min":275.15,"temp_max":275.37,"pressure":1012,"humidity":74},"visibility":10000,"wind":{"speed":2.1,"deg":130},"clouds":{"all":20},"dt":1581375043,"sys":{"type":1,"id":6366,"country":"BG","sunrise":1581399020,"sunset":1581436303},"timezone":7200,"id":727011,"name":"Sofia","cod":200}
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
