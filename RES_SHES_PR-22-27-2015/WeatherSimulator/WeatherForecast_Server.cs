using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;

namespace WeatherSimulator
{
    class WeatherForecast_Server
    {
        private ServiceHost _serviceHost;
        private String _hostAddress = "net.tcp://localhost:6001/WeathetForecast";

        public WeatherForecast_Server()
        {
            NetTcpBinding binding = new NetTcpBinding();
            _serviceHost = new ServiceHost(typeof(WeatherForecast_Provider));

            _serviceHost.AddServiceEndpoint(typeof(IWeatherForecast), binding, _hostAddress);

            Console.WriteLine("Server WEATHER initialized and ready to be opened.");

        }

        public void Open()
        {
            _serviceHost.Open();

            Console.WriteLine("Server WEATHER opened and ready and waiting for requests.");
        }

        public void Close()
        {
            _serviceHost.Close();

            Console.WriteLine("Server WEATHER closed.");
        }
    }
}
