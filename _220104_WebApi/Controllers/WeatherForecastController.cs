using _220104_WebApiLibrary01;
using Microsoft.AspNetCore.Mvc;

namespace _220104_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Student student;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Student student)
        {
            _logger = logger;
            this.student = student;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //设置缓存时间为5s
        [ResponseCache(Duration = 5)]
        [HttpGet]
        public string GetStudentHello()
        {
            return student.Hello();
        }
    }
}