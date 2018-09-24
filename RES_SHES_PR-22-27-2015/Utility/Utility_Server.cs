using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Utility_Server
    {
        public ServiceHost ServiceHost { get; }
        public String HostAddress { get; } = "net.tcp://localhost:6002/Utility";

        public Utility_Server()
        {
            NetTcpBinding binding = new NetTcpBinding();
            ServiceHost = new ServiceHost(typeof(Utility_Provider));

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
