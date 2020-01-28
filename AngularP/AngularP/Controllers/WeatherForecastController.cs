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
            var list = Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index).ToShortDateString(),
                Location = Locations[rng.Next(Locations.Length)],
                MaxTemperatureC = rng.Next(-20, 55),
                MinTemperatureC = rng.Next(-40, -20),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Title = "Sofia"
            })
            .Take(10).ToArray();

            var result = GetPictures(list);


            var b = await this.GetFromAPi("query");
            

            return result;

        }
            
        public async Task<WeatherForecast2> GetFromAPi(string query)
        {

            string _apiUrl = "http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=086f766a6e40a5e8f8b3b5d917fc4b31";                           

            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            //Check should we add json as media type or its added by default
            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            var responseMessage = await client.GetAsync(_apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                string myJsonAsString = await responseMessage.Content.ReadAsStringAsync();

                WeatherForecast2 myWeatherFromApi = JsonConvert.DeserializeObject<WeatherForecast2>(myJsonAsString);

                return myWeatherFromApi;
            }
            // if !IsSuccessStatusCode throw ex
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
