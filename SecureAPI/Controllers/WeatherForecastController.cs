using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using SecureAPI.Service;
using SecureAPI.Factory;

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
            //use factory pattern to avoid new class()
            //any chages to "WeatherForecastService" will be handled in helper 
            return WeatherForecastHelper.Create().GetWeatherForecast();
        }
    }
}
