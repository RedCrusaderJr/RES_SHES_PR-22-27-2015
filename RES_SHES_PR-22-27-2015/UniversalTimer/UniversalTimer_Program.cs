using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalTimer
{
    public class UniversalTimer_Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UniversalTimer: Hello world!");

            UniversalTimer_Server server = new UniversalTimer_Server();
            server.Open();
            Thread.Sleep(Constants.WAITING_TIME);

            while(true)
            {
                IUniversalTimer proxy = Connect();
                Console.WriteLine($"Global Time: Hours format[{proxy.GetGlobalTimeInHours()}]     " +
                                  $"Minutes format[{proxy.GetGlobalTimeInMinutes()}]     " +
                                  $"Seconds format[{proxy.GetGlobalTimeInSeconds()}]");

                Thread.Sleep(Constants.SECOND);
            }        
        }

        static IUniversalTimer Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();

            return new ChannelFactory<IUniversalTimer>(binding, new EndpointAddress("net.tcp://localhost:6000/UniversalTimer")).CreateChannel();
        }
    }
}
