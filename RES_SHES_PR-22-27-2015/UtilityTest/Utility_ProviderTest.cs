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
    public class Utility_ProviderTest
    {
        [Test]
        public void GetPowerPriceGoodExpample()
        {
            Utility_Provider up = new Utility_Provider();
            if(UniversalClock.S_Instance.TimeHours >= 1.0 && UniversalClock.S_Instance.TimeHours < 7.0)
            {
                Assert.AreEqual(up.GetPowerPrice(), Math.Round(2.372 / 101.94, 3));
            }
            else
            {
                Assert.AreEqual(up.GetPowerPrice(), Math.Round(7.117 / 101.94, 3));
            }
        }

        [Test]
        public void GetPowerPriceWithDateGoodExample()
        {
            Utility_Provider up = new Utility_Provider();
            if (UniversalClock.S_Instance.TimeHours >= 1.0 && UniversalClock.S_Instance.TimeHours < 7.0)
            {
                Assert.AreEqual(up.GetPowerPrice(), new Tuple<Tuple<int, double>, double>(
                                                        new Tuple<int, double>(
                                                            UniversalClock.S_Instance.TimeDay, 
                                                            UniversalClock.S_Instance.TimeHours),
                                                        Math.Round(2.372 / 101.94, 3)));
            }
            else
            {
                Assert.AreEqual(up.GetPowerPrice(), new Tuple<Tuple<int, double>, double>(
                                                        new Tuple<int, double>(
                                                            UniversalClock.S_Instance.TimeDay,
                                                            UniversalClock.S_Instance.TimeHours),
                                                        Math.Round(7.117 / 101.94, 3)));
            }
        }
    }
}
