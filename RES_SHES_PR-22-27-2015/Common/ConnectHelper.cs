using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ConnectHelper
    {
        public static IWeatherForecast ConnectWeatherForecast()
        {
            NetTcpBinding binding = new NetTcpBinding()
            {
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                SendTimeout = new TimeSpan(0, 10, 0),
            };

            return new ChannelFactory<IWeatherForecast>(binding, new EndpointAddress("net.tcp://localhost:6001/WeathetForecast")).CreateChannel();
        }

        public static IPowerPrice ConnectUtility()
        {
            NetTcpBinding binding = new NetTcpBinding()
            {
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                SendTimeout = new TimeSpan(0, 10, 0),
            };

            return new ChannelFactory<IPowerPrice>(binding, new EndpointAddress("net.tcp://localhost:6002/PowerPrice")).CreateChannel();
        }

        public static IUniversalClockService ConnectUniversalClock()
        {
            NetTcpBinding binding = new NetTcpBinding()
            {
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                SendTimeout = new TimeSpan(0, 10, 0),
            };

            return new ChannelFactory<IUniversalClockService>(binding, new EndpointAddress("net.tcp://localhost:6004/UniversalClock")).CreateChannel();
        }

        public static ISHES ConnectToSHES()
        {
            NetTcpBinding binding = new NetTcpBinding()
            {
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                SendTimeout = new TimeSpan(0, 10, 0),
            };
            return new ChannelFactory<ISHES>(binding, new EndpointAddress("net.tcp://localhost:6005/SHES")).CreateChannel();
        }
    }
}
