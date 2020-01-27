using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngularP.Models
{
    public class Clouds
    {
        //Rename this proprety
        [JsonProperty("all")]
        public int All { get; set; }

    }
}
