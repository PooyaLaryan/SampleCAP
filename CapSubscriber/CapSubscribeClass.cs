using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace CapSubscriber
{
    public class CapSubscribeClass : ICapSubscribe
    {
        [CapSubscribe("WeatherForecast", Group = "WebApi")]
        public void HandleWeatherForecast(IEnumerable<WeatherForecast> weatherForecasts)
        {
            Console.Clear();
            foreach (var item in weatherForecasts)
            {
                Console.WriteLine($@"
TemperatureC = {item.TemperatureC}
TemperatureF = {item.TemperatureF}
Summary = {item.Summary}
Date = {item.Date}
-------------------------------
"
                    );

                Console.WriteLine("WebApi End of consume");
            }
        }
    }
}
