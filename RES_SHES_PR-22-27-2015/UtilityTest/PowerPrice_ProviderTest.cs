using Common;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace UtilityTest
{
    [TestFixture]
    public class PowerPrice_ProviderTest
    {
        //TODO: predlog
        private IUniversalClockService _clockProxy1;
        private IUniversalClockService _clockProxy2;
        private IUniversalClockService _clockProxy3;

        [SetUp]
        public void SetUp()
        {
            Mock<IUniversalClockService> clockMoq = new Mock<IUniversalClockService>();
            clockMoq.Setup(uc => uc.GetTimeInHours()).Returns(1.00);
            clockMoq.Setup(uc => uc.GetDay()).Returns(1);
            _clockProxy1 = clockMoq.Object;

            clockMoq.Setup(uc => uc.GetTimeInHours()).Returns(12.00);
            clockMoq.Setup(uc => uc.GetDay()).Returns(5);
            _clockProxy2 = clockMoq.Object;

            clockMoq.Setup(uc => uc.GetTimeInHours()).Returns(20.5);
            clockMoq.Setup(uc => uc.GetDay()).Returns(3);
            _clockProxy3 = clockMoq.Object;    
        }

        [Test]
        public void GetPowerPriceGoodExpample1()
        {
            PowerPrice_Provider ppp = new PowerPrice_Provider();
            double hourOfTheDay = _clockProxy1.GetTimeInHours();

            if (hourOfTheDay >= 1.0 && hourOfTheDay < 7.0)
            {
                Assert.AreEqual(ppp.GetPowerPrice(hourOfTheDay), Math.Round(2.372 / 101.94, 3));
            }
            else
            {
                Assert.AreEqual(ppp.GetPowerPrice(hourOfTheDay), Math.Round(7.117 / 101.94, 3));
            }
        }
        [Test]
        public void GetPowerPriceWithDateGoodExample1()
        {
            PowerPrice_Provider ppp = new PowerPrice_Provider();
            double hourOfTheDay = _clockProxy1.GetTimeInHours();
            int day = _clockProxy1.GetDay();

            if (hourOfTheDay >= 1.0 && hourOfTheDay < 7.0)
            {
                Assert.AreEqual(ppp.GetPowerPriceWithDate(hourOfTheDay, day), new Tuple<Tuple<int, double>, double>(
                                                        new Tuple<int, double>(
                                                            day,
                                                            hourOfTheDay),
                                                        Math.Round(2.372 / 101.94, 3)));
            }
            else
            {
                Assert.AreEqual(ppp.GetPowerPriceWithDate(hourOfTheDay, day), new Tuple<Tuple<int, double>, double>(
                                                        new Tuple<int, double>(
                                                            day,
                                                            hourOfTheDay),
                                                        Math.Round(7.117 / 101.94, 3)));
            }
        }

        //TODO: EXAMPLE 2
        //TODO: EXAMPLE 3
    }
}
