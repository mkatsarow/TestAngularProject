using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AngularP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AngularP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly List<string> Locations = new List<string>
        {
            "Sofia", "London","Varna","Cebu", "Plovdiv","Mexico","Mexico"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly IHttpClientFactory clientFactory;
 
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IHttpClientFactory clientFactory)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Task.WhenAll(Locations.Select(x =>  GetList(x)));
        }

        public async Task<WeatherForecast> GetList(string city)
        {
            var tempUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&APPID=086f766a6e40a5e8f8b3b5d917fc4b31";

            var responseMessage = await this.clientFactory.CreateClient().GetAsync(tempUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                string myJsonAsString = await responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<WeatherForecast>(myJsonAsString);
            }
            else
            {
                this.logger.LogError($"City with {city} not found." +
                                     $" {responseMessage.Content}. At: {DateTime.UtcNow}");

                throw new ArgumentNullException();
            }
        }
    }
}
