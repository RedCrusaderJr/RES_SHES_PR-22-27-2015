using Moq;
using NUnit.Framework;
using SHES.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHESTest.Access
{
    [TestFixture]
    public class DBManagerTest
    {
        [SetUp]
        public void SetUp()
        {
            Mock<SolarPanel> mock = new Mock<SolarPanel>();
        }
    }
}
