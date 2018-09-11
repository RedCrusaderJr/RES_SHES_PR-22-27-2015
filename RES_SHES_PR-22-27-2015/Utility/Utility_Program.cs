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

            Utility_Server server = new Utility_Server();
            server.Open();
            Thread.Sleep(Constants.WAITING_TIME);

            IUniversalTimer proxy = Connect();
            double price = 0;
            double hourOfTheDay;

            double USDToRSDRatio = 101.94;
            double highPrice = 7.117 / USDToRSDRatio;
            double lowPrice = 2.372 / USDToRSDRatio;
            
            while (true)
            {
                hourOfTheDay = proxy.GetGlobalTimeInHours();
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
