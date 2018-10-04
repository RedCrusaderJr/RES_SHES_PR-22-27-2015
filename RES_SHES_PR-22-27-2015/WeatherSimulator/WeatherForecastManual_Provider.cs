﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    public class WeatherForecastManual_Provider : IWeatherForecast
    {
        public int GetSunlightPercentage(double hourOfTheDay)
        {
            return WeatherForecastManual_Server.CurrentSunlight;
        }
    }
}
