using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility;

namespace Utility
{
    public class Utility_Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Utility: Hello world!");

            PowerPrice_Server server = new PowerPrice_Server();
            server.Open();
            Thread.Sleep(Constants.WAITING_TIME);

            double price = 0;
            double hourOfTheDay;

            double USDToRSDRatio = 101.94;
            double highPrice = 7.117 / USDToRSDRatio;
            double lowPrice = 2.372 / USDToRSDRatio;
            
            while (true)
            {
                hourOfTheDay = ConnectHelper.ConnectUniversalClock().GetTimeInHours();
                price = (hourOfTheDay >= 1.0 && hourOfTheDay < 7.0) ? lowPrice : highPrice;
                
                Console.WriteLine($"Price of kwh ($/kwh): {Math.Round(price, 5)}   time[{hourOfTheDay}]");
                Thread.Sleep(500);
            }
            
        }
    }
}
