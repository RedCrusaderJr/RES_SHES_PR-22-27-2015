using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{
    public class SHES_Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SHES: Hello world!");

            IUniversalTimer proxy = Connect();

            Console.WriteLine("Timer started");

            while(true)
            {
                Console.WriteLine($"Global Time: Hours format[{proxy.GetGlobalTimeInHours()}]     Minutes format[{proxy.GetGlobalTimeInMinutes()}]     Seconds format[{proxy.GetGlobalTimeInSeconds()}]");
                Thread.Sleep(1000);
            }
        }

        static IUniversalTimer Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();

            return new ChannelFactory<IUniversalTimer>(binding, new EndpointAddress("net.tcp://localhost:6000/UniversalTimer")).CreateChannel();
        }
    }
}
