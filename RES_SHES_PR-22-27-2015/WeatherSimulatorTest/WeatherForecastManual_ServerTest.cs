using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherSimulator;
using Common;
using System.ServiceModel;

namespace WeatherSimulatorTest
{
    [TestFixture]
    class WeatherForecastManual_ServerTest
    {
        [Test]
        public void WeatherForecastManual_ServerConstructorGoodExample()
        {
            WeatherForecastManual_Server server = new WeatherForecastManual_Server();

            Assert.AreEqual(server._serviceHost, CommunicationState.Created);
            Assert.AreEqual(server._serviceHost.Extensions.Count, 1);
        }

        [Test]
        public void WeatherForecastManual_ServerOpenServiceGoodExample()
        {
            WeatherForecastManual_Server server = new WeatherForecastManual_Server();
            Assert.DoesNotThrow(() => server.Open());
        }

        [Test]
        public void WeatherForecastManual_ServerCloseServiceGoodExample()
        {
            WeatherForecastManual_Server server = new WeatherForecastManual_Server();
            server.Open();

            Assert.DoesNotThrow(() => server.Close());
        }
    }
}
