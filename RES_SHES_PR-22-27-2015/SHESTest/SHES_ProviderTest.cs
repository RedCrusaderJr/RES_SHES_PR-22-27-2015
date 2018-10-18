using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Moq;
using NUnit.Framework;
using SHES;

namespace SHESTest
{
    [TestFixture]
    class SHES_ProviderTest
    {
        [Test]
        [TestCase(12.5)]
        public void TotalHoursToString_GoodExample1(double hours)
        {
            SHES_Provider provider = new SHES_Provider();

            string sHours = provider.TotalHoursToString(hours);

            Assert.AreEqual(sHours, "12 : 30");
        }

        [Test]
        [TestCase(15.5)]
        public void TotalHoursToString_GoodExample2(double hours)
        {
            SHES_Provider provider = new SHES_Provider();

            string sHours = provider.TotalHoursToString(hours);

            Assert.AreEqual(sHours, "15 : 30");
        }

        [Test]
        [TestCase(17)]
        public void TotalHoursToString_GoodExample3(double hours)
        {
            SHES_Provider provider = new SHES_Provider();

            string sHours = provider.TotalHoursToString(hours);

            Assert.AreEqual(sHours, "17 : 0");
        }

        [Test]
        [TestCase(23)]
        public void TotalHoursToString_GoodExample4(double hours)
        {
            SHES_Provider provider = new SHES_Provider();

            string sHours = provider.TotalHoursToString(hours);

            Assert.AreEqual(sHours, "23 : 0");
        }

        [Test]
        [TestCase(23.5)]
        public void TotalHoursToString_GoodExample5(double hours)
        {
            SHES_Provider provider = new SHES_Provider();

            string sHours = provider.TotalHoursToString(hours);

            Assert.AreEqual(sHours, "23 : 30");
        }
    }
}
