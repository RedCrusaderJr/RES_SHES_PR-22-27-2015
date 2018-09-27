using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;


namespace WeatherSimulator
{
    public class WeatherForecast_Provider : IWeatherForecast
    {
        public int GetSunlightPercentage()
        {
            int sunlightPercentage = 0;
            Random random = new Random();


            double hourOfTheDay = UniversalClock.S_Instance.TimeHours;

            if (hourOfTheDay >= 0 && hourOfTheDay < 5.5)
            {
                sunlightPercentage = 0;
            }
            else if (hourOfTheDay >= 5.5 && hourOfTheDay < 7.0)
            {
                sunlightPercentage = 25 * random.Next(8, 10) / 10;
            }
            else if (hourOfTheDay >= 7.0 && hourOfTheDay < 10.0)
            {
                sunlightPercentage = 50 * random.Next(8, 10) / 10;
            }
            else if (hourOfTheDay >= 10.0 && hourOfTheDay < 12.0)
            {
                sunlightPercentage = 75 * random.Next(8, 10) / 10;
            }
            else if (hourOfTheDay >= 12.0 && hourOfTheDay < 15.0)
            {
                sunlightPercentage = 100 * random.Next(8, 10) / 10;
            }
            else if (hourOfTheDay >= 15.0 && hourOfTheDay < 17.0)
            {
                sunlightPercentage = 75 * random.Next(8, 10) / 10;
            }
            else if (hourOfTheDay >= 17.0 && hourOfTheDay < 20.0)
            {
                sunlightPercentage = 50 * random.Next(8, 10) / 10;
            }
            else if (hourOfTheDay >= 20.0 && hourOfTheDay < 22.0)
            {
                sunlightPercentage = 25 * random.Next(8, 10) / 10;
            }
            else if (hourOfTheDay >= 22.0 && hourOfTheDay <= 23.0)
            {
                sunlightPercentage = 0;
            }
            else
            {
                sunlightPercentage = -1;
            }

            return sunlightPercentage;
        }
    }
}
