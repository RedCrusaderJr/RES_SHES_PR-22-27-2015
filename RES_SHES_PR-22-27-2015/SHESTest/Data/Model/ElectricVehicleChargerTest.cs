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
    class ElectricVehicleChargerTest
    {
        [Test]
        [TestCase("abc")]
        [TestCase("xxx")]
        public void EVCConstructor_GoodExample(string id)
        {
            ElectricVehicleCharger evc = new ElectricVehicleCharger(id);

            Assert.AreEqual(evc.BatteryID, id);
        }


        [Test]
        [TestCase("")]
        public void EVCConstructor_BadExample1(string id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ElectricVehicleCharger evc = new ElectricVehicleCharger(id);
            }
            );
        }


        [Test]
        [TestCase(null)]
        public void EVCConstructor_BadExample2(string id)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ElectricVehicleCharger evc = new ElectricVehicleCharger(id);
            }
            );
        }


        [Test]
        [TestCase(null)]
        public void EVCConstructor2_BadExample(ElectricVehicleCharger evc)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ElectricVehicleCharger new_evc = new ElectricVehicleCharger(evc);
            }
            );
        }
    }
}
