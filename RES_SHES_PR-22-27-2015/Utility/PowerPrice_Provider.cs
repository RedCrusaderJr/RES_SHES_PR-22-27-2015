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
    public class PowerPrice_Provider : IPowerPrice
    {
        public double GetPowerPrice(double hourOfTheDay)
        {
            double price = 0;

            double USDToRSDRatio = 101.94;
            double highPrice = Math.Round(7.117 / USDToRSDRatio, 3);
            double lowPrice = Math.Round(2.372 / USDToRSDRatio, 3);

            //double hourOfTheDay = ConnectHelper.ConnectUniversalClock().GetTimeInHours();

            price = (hourOfTheDay >= 1.0 && hourOfTheDay < 7.0) ? lowPrice : highPrice;

            return price;
        }

        public Tuple<Tuple<int, double>, double> GetPowerPriceWithDate(Double hourOfTheDay, Int32 day)
        {
            double price = 0;

            double USDToRSDRatio = 101.94;
            double highPrice = Math.Round(7.117 / USDToRSDRatio, 3);
            double lowPrice = Math.Round(2.372 / USDToRSDRatio, 3);

            //Double hourOfTheDay = ConnectHelper.ConnectUniversalClock().GetTimeInHours();

            price = (hourOfTheDay >= 1.0 && hourOfTheDay < 7.0) ? lowPrice : highPrice;
            
            //ConnectHelper.ConnectUniversalClock().GetDay()
            return new Tuple<Tuple<int, double>, double>(new Tuple<int, double>(day, hourOfTheDay), price);
        }
    }
}
