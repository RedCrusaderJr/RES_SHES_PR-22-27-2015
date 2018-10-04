using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SHES.Data.Model;

namespace SHESTest.Data.Model
{
    class ElectricVehicleChargerTest
    {
        // TODO

        [Test]
        [TestCase("abc")]
        [TestCase("xxx")]
        public void EVCConstructor_GoodExample(string id)
        {
            ElectricVehicleCharger evc = new ElectricVehicleCharger(id);

            Assert.AreEqual(evc.BatteryID, id);
        }

        //TODO svi konstruktori
    }
}
