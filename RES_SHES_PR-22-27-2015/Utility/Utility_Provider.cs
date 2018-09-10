using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace Utility
{
    class Utility_Provider : IPowerPrice
    {
        public double GetPowerPrice()
        {
            IUniversalTimer proxy = Connect();
            double price = 0;

            double USDToRSDRatio = 101.94;
            double highPrice = 7.117 / USDToRSDRatio;
            double lowPrice = 2.372 / USDToRSDRatio;

            double hourOfTheDay = proxy.GetGlobalTimeInHours();

            price = (hourOfTheDay >= 1.0 && hourOfTheDay < 7.0) ? lowPrice : highPrice;

            return price;
        }

        private IUniversalTimer Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();

            return new ChannelFactory<IUniversalTimer>(binding, new EndpointAddress("net.tcp://localhost:6000/UniversalTimer")).CreateChannel();
        }
    }
}
