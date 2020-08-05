using SecureAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureAPI.Extension
{
    /// <summary>
    /// Extension method for WeatherForecast
    /// </summary>
    public static class WeatherForecastExtension
    {
        public static string TakeSports(this WeatherForecast _this)
        {
            if (_this.TemperatureC < 0)
                return WeatherForecastInfo.WinterSports;
            return WeatherForecastInfo.SummerSports;
        }
    }
}
