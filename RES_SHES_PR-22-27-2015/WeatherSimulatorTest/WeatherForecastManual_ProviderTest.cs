using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;
using WeatherSimulator;
using System.ServiceModel;
using Moq;

namespace WeatherSimulatorTest
{
    [TestFixture]
    class WeatherForecastManual_ProviderTest
    {
        /*
        private WeatherForecastManual_Server server;

        
        [SetUp]
        public void SetUp()
        {
            Mock<WeatherForecastManual_Server> serverMoq = new Mock<WeatherForecastManual_Server>();
            serverMoq.Setup(sm => sm.CurrentSunlight) //static metode se ne mogu mokovati
            WeatherForecastManual_Server.currentSunligh
        }
        */

        [Test]
        public void GetSunlightPercentageGoodExample()
        {
            /*
            WeatherForecastManual_Provider provider = new WeatherForecastManual_Provider();

            int sunLightPersentage = 15;
            WeatherForecast_Server server = new WeatherForecast_Server();
            WeatherForecast_Server.CurrentSunlight = sunLightPersentage;

            Assert.AreEqual(provider.GetSunlightPercentage(0), WeatherForecast_Server.CurrentSunlight);
            */
        }
    }
}
