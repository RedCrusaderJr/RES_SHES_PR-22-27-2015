using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utility
{
    public class Utility_Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Utility: Hello world!");

            IUniversalTimer proxy = Connect();

            double USDToRSDRatio = 101.94;
            double highPrice = 7.117 / USDToRSDRatio;
            double lowPrice = 2.372 / USDToRSDRatio;
            double price = 0;

            while (true)
            {
                double hourOfTheDay = proxy.GetGlobalTimeInHours();

                price = (hourOfTheDay >= 1.0 && hourOfTheDay < 7.0) ? lowPrice : highPrice;

                Console.WriteLine($"Price of kwh ($/kwh): {Math.Round(price, 5)}   time[{hourOfTheDay}]");
                Thread.Sleep(500);
            }
            
        }

        static IUniversalTimer Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();

            return new ChannelFactory<IUniversalTimer>(binding, new EndpointAddress("net.tcp://localhost:6000/UniversalTimer")).CreateChannel();
        }
    }
}
