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
            "Sofia", "London","Varna","Cebu", "Plovdiv","Mexico"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly IHttpClientFactory clientFactory;
        private const string baseUrl = "http://api.openweathermap.org/data/2.5/weather?q=Sofia&APPID=086f766a6e40a5e8f8b3b5d917fc4b31";

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                        IHttpClientFactory clientFactory)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var result = new List<WeatherForecast>();

            Func<string, WeatherForecast> test = x => GetList(x).Result;

             Locations.ForEach(x =>  GetList(x));


            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            // Determine whether any string in the array is longer than "banana".
            string longestName =
                fruits.Aggregate("banana",
                                (longest, next) =>
                                    next.Length > longest.Length ? next : longest,
                                // Return the final result as an upper case string.
                                fruit => fruit.ToUpper());

            var testResult = Locations.Aggregate((current, next) => current + GetList(next));



            foreach (var item in Locations)
            {
                result.Add(await GetList(item));
            }

            return result;
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
                this.logger.LogError($"City with name not found." +
                                     $" {responseMessage.Content}. At: {DateTime.UtcNow}");

                throw new ArgumentNullException();
            }
        }
    }
}
