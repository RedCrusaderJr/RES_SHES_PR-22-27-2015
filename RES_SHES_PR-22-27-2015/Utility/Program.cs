using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Utility: Hello world!");

            UniversalTime globalTime = UniversalTime.S_UniversalTime;

            double USDToRSDRatio = 101.94;
            double highPrice = 7.117 / USDToRSDRatio;
            double lowPrice = 2.372 / USDToRSDRatio;
            double price = 0;

            while (true)
            {
                double hourOfTheDay = globalTime.GetTimeInHours();

                price = (hourOfTheDay >= 1.0 && hourOfTheDay < 7.0) ? lowPrice : highPrice;

                Console.WriteLine($"Price of kwh ($/kwh): {Math.Round(price, 5)}   time[{hourOfTheDay}]");
                Thread.Sleep(2000);
            }
            
        }
    }
}
