using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngularP.Models
{
    public class Wind
    {
        [JsonProperty]
        public double Speed { get; set; }
        [JsonProperty]
        public double Deg { get; set; }
    }
}
