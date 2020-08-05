using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using SecureAPI.Extension;
using SecureAPI.Factory;
using System;

namespace SecureAPI.Controllers
{
    /// <summary>
    /// Please check 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;


        public WeatherForecastController(ILogger<WeatherForecastController> logger) 
        {
            _logger = logger;
        }

        /// <summary>
        /// Use Azure AD from https://www.youtube.com/watch?v=3PyUjOmuFic
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            WeatherForecast weatherForecast = new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = 37,
                Summary = "Hot"
            };

            var sports = weatherForecast.TakeSports();
            //use factory pattern to avoid new class()
            //any chages to "WeatherForecastService" will be handled in helper 
            return WeatherForecastHelper.Create().GetWeatherForecast();
        }
    }
}
