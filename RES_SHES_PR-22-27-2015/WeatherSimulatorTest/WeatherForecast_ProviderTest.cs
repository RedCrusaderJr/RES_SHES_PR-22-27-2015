using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;
using WeatherSimulator;

namespace WeatherSimulatorTest
{
    [TestFixture]
    public class WeatherForecast_ProviderTest
    {
        [Test]
        public void GetSunlightPercentageGoodExample()
        {
            WeatherForecast_Provider x = new WeatherForecast_Provider();
            double hourOfTheDay = UniversalClock.S_Instance.TimeHours;


            if(hourOfTheDay >= 0 && hourOfTheDay < 5.5)
            {
                Assert.AreEqual(x.GetSunlightPercentage(), 0);
            }
            else if (hourOfTheDay >= 5.5 && hourOfTheDay < 7.0)
            {
                Assert.GreaterOrEqual(x.GetSunlightPercentage(), 25 * (8 / 10));
                Assert.LessOrEqual(x.GetSunlightPercentage(), 25 * (10 / 10));
            }
            else if (hourOfTheDay >= 7.0 && hourOfTheDay < 10.0)
            {
                Assert.GreaterOrEqual(x.GetSunlightPercentage(), 50 * (8 / 10));
                Assert.LessOrEqual(x.GetSunlightPercentage(), 50 * (10 / 10));
            }
            else if (hourOfTheDay >= 10.0 && hourOfTheDay < 12.0)
            {
                Assert.GreaterOrEqual(x.GetSunlightPercentage(), 75 * (8 / 10));
                Assert.LessOrEqual(x.GetSunlightPercentage(), 75 * (10 / 10));
            }
            else if (hourOfTheDay >= 12.0 && hourOfTheDay < 15.0)
            {
                Assert.GreaterOrEqual(x.GetSunlightPercentage(), 100 * (8 / 10));
                Assert.LessOrEqual(x.GetSunlightPercentage(), 100 * (10 / 10));
            }
            else if (hourOfTheDay >= 15.0 && hourOfTheDay < 17.0)
            {
                Assert.GreaterOrEqual(x.GetSunlightPercentage(), 75 * (8 / 10));
                Assert.LessOrEqual(x.GetSunlightPercentage(), 75 * (10 / 10));
            }
            else if (hourOfTheDay >= 17.0 && hourOfTheDay < 20.0)
            {
                Assert.GreaterOrEqual(x.GetSunlightPercentage(), 50 * (8 / 10));
                Assert.LessOrEqual(x.GetSunlightPercentage(), 50 * (10 / 10));
            }
            else if (hourOfTheDay >= 20.0 && hourOfTheDay < 22.0)
            {
                Assert.GreaterOrEqual(x.GetSunlightPercentage(), 25 * (8 / 10));
                Assert.LessOrEqual(x.GetSunlightPercentage(), 25 * (10 / 10));
            }
            else if (hourOfTheDay >= 22.0 && hourOfTheDay <= 23.0)
            {
                Assert.AreEqual(x.GetSunlightPercentage(), 0);
            }
            else
            {
                Assert.AreEqual(x.GetSunlightPercentage(), -1);
            }
        }
    }
}
