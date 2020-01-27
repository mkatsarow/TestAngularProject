using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AngularP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] Locations = new[]
        {
            "Sofia", "Plovdiv", "Varna"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {


            var rng = new Random();
            var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index).ToShortDateString(),
                Location = Locations[rng.Next(Locations.Length)],
                MaxTemperatureC = rng.Next(-20, 55),
                MinTemperatureC = rng.Next(-40, -20),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Title = "Sofia"
            })
            .Take(5).ToArray();

            var result = GetPictures(list);


            //var b = await this.GetFromAPi("query");
            

            return result;

        }
            
        public async Task<Weather> GetFromAPi(string query)
        {

            string _apiUrl = "https://api.openweathermap.org/data/2.5/weather?=London,uk&APPID=086f766a6e40a5e8f8b3b5d917fc4b31";                           

            //// SpaceX get URL
            //string _apiUrl = "https://api.spacexdata.com/v3/launches/latest";

            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            //Check should we add json as media type or its added by default
            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            var responseMessage = await client.GetAsync(_apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                string myJsonAsString = await responseMessage.Content.ReadAsStringAsync();
            
                Weather myWeatherFromApi = JsonConvert.DeserializeObject<Weather>(myJsonAsString);

                return myWeatherFromApi;
            }

            return null;
        }

        public IEnumerable<WeatherForecast> GetPictures(IEnumerable<WeatherForecast> weather)
        {
            foreach (var item in weather)
            {
                if (item.MaxTemperatureC >= 0)
                {
                    item.Image = "Img/Summer.jfif";
                }
                else
                {
                    item.Image = "Img/Winter.jfif";
                }
            }

            return weather;
        }
    }
}
