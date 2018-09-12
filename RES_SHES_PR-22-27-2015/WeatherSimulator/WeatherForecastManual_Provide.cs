using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    class WeatherForecastManual_Provide : IWeatherForecast
    {
        public int GetSunlightPercentage()
        {
            return WeatherForecast_Server.currentSunlight;
        }  
    }
}
