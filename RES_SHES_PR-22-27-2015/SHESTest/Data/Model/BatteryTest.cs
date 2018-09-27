using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SHES.Data.Model;

namespace SHESTest.Data.Model
{
    [TestFixture]
    class BatteryTest
    {
        [Test]
        [TestCase("abc")]
        [TestCase("xxx")]
        public void BatteryConstructor_GoodExample(string id)
        {
            Battery b = new Battery(id);

            Assert.AreEqual(b.BatteryID, id);
        }

        [Test]
        [TestCase("")]
        public void BatteryConstructor_BadExample1(string id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Battery b = new Battery(id);
            }
            );
        }

        [Test]
        [TestCase(null)]
        public void BatteryConstructor_BadExample2(string id)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Battery b = new Battery(id);
            }
            );
        }


        [Test]
        [TestCase(null)]
        public void BatteryConstructor2_BadExample(Battery b)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Battery new_battery = new Battery(b);
            }
            );
        }
    }
}
