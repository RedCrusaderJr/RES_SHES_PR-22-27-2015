using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    public class WeatherSimulator_Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WeatherSimulator: Hello world!");

            WeatherForecast_Server server = new WeatherForecast_Server();
            WeatherForecastManual_Server serverManual = new WeatherForecastManual_Server();

            Int32.TryParse(args[0], out int answer);

            if (answer == 1)
            {
                Automatic(server);
            }
            else if (answer == 2)
            {
                Manual(serverManual);
            }
        }

        private static void Manual(WeatherForecastManual_Server serverManual)
        {
            WeatherForecastManual_Server.currentSunlight = 0;

            serverManual.Open();
            Thread.Sleep(Constants.WAITING_TIME);

            int answer = 0;
            while (true)
            {
                Console.Write("Set sunlight [%]: ");
                Int32.TryParse(Console.ReadLine(), out answer);

                if (answer != -1)
                {
                    WeatherForecastManual_Server.currentSunlight = answer;
                }
            }
        }

        static void Automatic(WeatherForecast_Server server)
        {

            //probaj sa currentSunlight

            server.Open();
            Thread.Sleep(Constants.WAITING_TIME);

            int sunlightPercentage = 0;
            Random random = new Random();

            while (true)
            {
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


                // TODO
                // da li je ova dodela ok

                WeatherForecast_Server.currentSunlight = sunlightPercentage;

                //

                Console.WriteLine($"Sunlight(%): {sunlightPercentage}   time[{hourOfTheDay}]");
                Thread.Sleep(Constants.MILISECONDS_IN_SECOND);
            }
        }
    }
}