using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ultimate_asp_net_core_web_api_2nd_edition.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILoggerManager _logger;
    public WeatherForecastController(ILoggerManager logger)
    {
        _logger = logger;
    }

    public IEnumerable<string> GetLogger()
    {
        _logger.LogInfo("Here is info message from our values controller");
        _logger.LogDebug("Here is debug message from our values controller");
        _logger.LogWarn("Here is warn message from our values controller");
        _logger.LogError("Here is error message from our values controller");

        return new string[] { "value1", "value2" };
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}