using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UniversalTimer
{
    public class UniversalTimer_Server
    {
        private ServiceHost _serviceHost;
        private String _hostAddress = "net.tcp://localhost:6000/UniversalTimer";

        public UniversalTimer_Server()
        {
            NetTcpBinding binding = new NetTcpBinding();
            _serviceHost = new ServiceHost(typeof(UniversalTimer_Provider));


            _serviceHost.AddServiceEndpoint(typeof(IUniversalTimer), binding, _hostAddress);

            Console.WriteLine("Server TIMER initialized and ready to be opened.");
        }

        public void Open()
        {
            _serviceHost.Open();

            Console.WriteLine("Server TIMER opened and ready and waiting for requests.");
        }

        public void Close()
        {
            _serviceHost.Close();

            Console.WriteLine("Server TIMER closed.");
        }
    }
}
