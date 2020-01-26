using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public IEnumerable<WeatherForecast> Get()
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

            return result;

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
