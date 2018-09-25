using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class PowerPrice_Server
    {
        public ServiceHost ServiceHost { get; }
        public String HostAddress { get; } = "net.tcp://localhost:6002/PowerPrice";

        public PowerPrice_Server()
        {
            NetTcpBinding binding = new NetTcpBinding()
            {
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                SendTimeout = new TimeSpan(0, 10, 0),
            };
            ServiceHost = new ServiceHost(typeof(PowerPrice_Provider));

            ServiceHost.AddServiceEndpoint(typeof(IPowerPrice), binding, HostAddress);

            Console.WriteLine("Server UTILITY initialized and ready to be opened.");
        }

        public void Open() 
        {
            ServiceHost.Open();

            Console.WriteLine("Server UTILITY opened and ready and waiting for requests.");
        }

        public void Close()
        {
            ServiceHost.Close();

            Console.WriteLine("Server UTILITY closed.");
        }
    }
}
