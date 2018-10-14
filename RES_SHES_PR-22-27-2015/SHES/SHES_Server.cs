using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class SHES_Server
    {
        public ServiceHost _serviceHost;
        public String _hostAddress = "net.tcp://localhost:6005/SHES";

        public SHES_Server()
        {
            NetTcpBinding binding = new NetTcpBinding()
            {
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                SendTimeout = new TimeSpan(0, 10, 0),
            };
            _serviceHost = new ServiceHost(typeof(SHES_Provider));

            _serviceHost.AddServiceEndpoint(typeof(ISHES), binding, _hostAddress);

            Console.WriteLine("Server WEATHER initialized and ready to be opened.");

        }

        public void Open()
        {
            _serviceHost.Open();

            Console.WriteLine("Server SHES opened and ready and waiting for requests.");
        }

        public void Close()
        {
            _serviceHost.Close();

            Console.WriteLine("Server SHES closed.");
        }
    }
}
