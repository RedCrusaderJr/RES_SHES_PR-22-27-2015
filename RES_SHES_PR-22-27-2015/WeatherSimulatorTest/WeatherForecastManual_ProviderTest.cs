using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;
using WeatherSimulator;
using System.ServiceModel;

namespace WeatherSimulatorTest
{
    [TestFixture]
    class WeatherForecastManual_ProviderTest
    {
        [Test]
        public void GetSunlightPercentageGoodExample()
        {
            WeatherForecastManual_Provider x = new WeatherForecastManual_Provider();

            Assert.AreEqual(x.GetSunlightPercentage(), WeatherForecastManual_Server.currentSunlight);
        }
    }
}
