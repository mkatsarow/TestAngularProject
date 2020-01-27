using System;

namespace AngularP
{
    public class WeatherForecast
    {
        public string Date { get; set; }
        public string Location { get; set; }
        public int MaxTemperatureC { get; set; }
        public int MaxTemperatureF => 32 + (int)(MaxTemperatureC / 0.5556);
        public int MinTemperatureC { get; set; }
        public int MinTemperatureF => 32 + (int)(MinTemperatureC / 0.5556);

        public int[] Hours = new int[24];
        public string Summary { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }

    }
}
