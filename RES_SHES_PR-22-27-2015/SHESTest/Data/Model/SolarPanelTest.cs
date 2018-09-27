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
    class SolarPanelTest
    {
        [Test]
        [TestCase("abc")]
        [TestCase("xxx")]
        public void SolarPanelConstructor_GoodExample(string id)
        {
            SolarPanel sp = new SolarPanel(id);

            Assert.AreEqual(sp.SolarPanelID, id);
        }

        [Test]
        [TestCase("")]
        public void SolarPanelConstructor_BadExample1(string id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                SolarPanel sp = new SolarPanel(id);
            }
            );
        }

        [Test]
        [TestCase(null)]
        public void SolarPanelConstructor_BadExample2(string id)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                SolarPanel sp = new SolarPanel(id);
            }
            );
        }



        // TODO

        // kako da testiram konstruktor sa taskom
    }
}
