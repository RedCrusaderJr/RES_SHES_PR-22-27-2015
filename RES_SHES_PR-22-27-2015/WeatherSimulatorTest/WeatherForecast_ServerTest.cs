using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherSimulator;
using Common;
using System.ServiceModel;

namespace WeatherSimulatorTest
{
    [TestFixture]
    class WeatherForecast_ServerTest
    {
        [Test]
        public void WeatherForecast_ServerConstructorGoodExample()
        {
            WeatherForecast_Server server = new WeatherForecast_Server();

            Assert.AreEqual(server._serviceHost.State, CommunicationState.Created);
            Assert.AreEqual(server._serviceHost.Extensions.Count, 1);
        }

        [Test]
        public void WeatherForecast_ServerOpenServiceGoodExample()
        {
            WeatherForecast_Server server = new WeatherForecast_Server();
            Assert.DoesNotThrow(() => server.Open());
        }

        [Test]
        public void WeatherForecast_ServerCloseServiceGoodExample()
        {
            WeatherForecast_Server server = new WeatherForecast_Server();
            server.Open();

            Assert.DoesNotThrow(() => server.Close());
        }
    }
}
