using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UniversalTimer;
using Common;

namespace UniversalTimerTest
{
    [TestFixture]
    class UniversalClock_ProviderTest
    {
        [Test]
        public void GetDayTesting()
        {
            UniversalClock_Provider x = new UniversalClock_Provider();
            Assert.AreEqual(x.GetDay(), UniversalClock.S_Instance.TimeDay);
        }

        [Test]
        public void GetTimeInMinutesTesting()
        {
            UniversalClock_Provider x = new UniversalClock_Provider();
            Assert.AreEqual(x.GetTimeInMinutes(), UniversalClock.S_Instance.TimeMinutes);
        }
    }
}
