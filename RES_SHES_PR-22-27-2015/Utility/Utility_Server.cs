using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    class Utility_Server
    {
        private ServiceHost _serviceHost;
        private String _hostAddress = "net.tcp://localhost:6001/Utility";

        public Utility_Server()
        {
            NetTcpBinding binding = new NetTcpBinding();
            _serviceHost = new ServiceHost(typeof(Utility_Provider));

            _serviceHost.AddServiceEndpoint(typeof(IPowerPrice), binding, _hostAddress);

            Console.WriteLine("Server UTILITY initialized and ready to be opened.");
        }

        public void Open()
        {
            _serviceHost.Open();

            Console.WriteLine("Server UTILITY opened and ready and waiting for requests.");
        }

        public void Close()
        {
            _serviceHost.Close();

            Console.WriteLine("Server UTILITY closed.");
        }
    }
}
