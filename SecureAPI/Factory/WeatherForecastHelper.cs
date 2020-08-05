using SecureAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureAPI.Factory
{
    public static class WeatherForecastHelper 
    {

        public static WeatherForecastService Create()
        {
            return new WeatherForecastService();
        }
    }
}
