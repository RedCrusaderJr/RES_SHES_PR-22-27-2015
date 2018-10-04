using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common;
using Moq;
using NUnit.Framework;
using WeatherSimulator;

namespace WeatherSimulatorTest
{
    [TestFixture]
    public class WeatherForecast_ProviderTest
    {
        //TODO: predlog
        private IUniversalClockService _clockProxy1;
        private IUniversalClockService _clockProxy2;
        private IUniversalClockService _clockProxy3;

        [SetUp]
        public void SetUp()
        {
            Mock<IUniversalClockService> proxyMoq = new Mock<IUniversalClockService>();
            proxyMoq.Setup(uc => uc.GetTimeInHours()).Returns(1.00);
            _clockProxy1 = proxyMoq.Object;

            proxyMoq.Setup(uc => uc.GetTimeInHours()).Returns(12.00);
            _clockProxy2 = proxyMoq.Object;

            proxyMoq.Setup(uc => uc.GetTimeInHours()).Returns(20.5);
            _clockProxy3 = proxyMoq.Object;
        }

        [Test]
        public void GetSunlightPercentageGoodExample1()
        {
            WeatherForecast_Provider provider = new WeatherForecast_Provider();
            double hourOfTheDay = _clockProxy1.GetTimeInHours();

            if(hourOfTheDay >= 0 && hourOfTheDay < 5.5)
            {
                Assert.AreEqual(provider.GetSunlightPercentage(hourOfTheDay), 0);
            }
            else if (hourOfTheDay >= 5.5 && hourOfTheDay < 7.0)
            {
                Assert.GreaterOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 25 * (8 / 10));
                Assert.LessOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 25 * (10 / 10));
            }
            else if (hourOfTheDay >= 7.0 && hourOfTheDay < 10.0)
            {
                Assert.GreaterOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 50 * (8 / 10));
                Assert.LessOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 50 * (10 / 10));
            }
            else if (hourOfTheDay >= 10.0 && hourOfTheDay < 12.0)
            {
                Assert.GreaterOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 75 * (8 / 10));
                Assert.LessOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 75 * (10 / 10));
            }
            else if (hourOfTheDay >= 12.0 && hourOfTheDay < 15.0)
            {
                Assert.GreaterOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 100 * (8 / 10));
                Assert.LessOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 100 * (10 / 10));
            }
            else if (hourOfTheDay >= 15.0 && hourOfTheDay < 17.0)
            {
                Assert.GreaterOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 75 * (8 / 10));
                Assert.LessOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 75 * (10 / 10));
            }
            else if (hourOfTheDay >= 17.0 && hourOfTheDay < 20.0)
            {
                Assert.GreaterOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 50 * (8 / 10));
                Assert.LessOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 50 * (10 / 10));
            }
            else if (hourOfTheDay >= 20.0 && hourOfTheDay < 22.0)
            {
                Assert.GreaterOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 25 * (8 / 10));
                Assert.LessOrEqual(provider.GetSunlightPercentage(hourOfTheDay), 25 * (10 / 10));
            }
            else if (hourOfTheDay >= 22.0 && hourOfTheDay <= 23.0)
            {
                Assert.AreEqual(provider.GetSunlightPercentage(hourOfTheDay), 0);
            }
            else
            {
                Assert.AreEqual(provider.GetSunlightPercentage(hourOfTheDay), -1);
            }
        }

        [Test]
        public void GetSunlightPercentageGoodExample2()
        {
            //TODO
        }

        [Test]
        public void GetSunlightPercentageGoodExample3()
        {
            //TODO
        }
    }
}
