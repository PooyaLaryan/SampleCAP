using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace CapSubscriber
{
    public class CapSubscribeClass : ICapSubscribe
    {
        [CapSubscribe("WeatherForecast")]
        public void HandleOrderCreated(IEnumerable<WeatherForecast> weatherForecasts)
        {
            foreach (var item in weatherForecasts)
            {
                Console.WriteLine(item.TemperatureC);
            }
        }
    }
}
