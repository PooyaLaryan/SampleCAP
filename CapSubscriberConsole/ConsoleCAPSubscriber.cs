using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapSubscriberConsole;

public class ConsoleCAPSubscriber : ICapSubscribe
{
    [CapSubscribe("WeatherForecast", Group = "Console")]
    public void Test(IEnumerable<WeatherForecast> weatherForecasts)
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

            Console.WriteLine("Console End of consume");
        }
    }
}
