using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace UtilityTest
{
    [TestFixture]
    class PowerPrice_ServerTest
    {
        [Test]
        public void Utility_ServerConstructorGoodExample()
        {
            PowerPrice_Server server = new Utility.PowerPrice_Server();

            Assert.AreEqual(server.ServiceHost.State, CommunicationState.Created);
            Assert.AreEqual(server.ServiceHost.Extensions.Count, 1);
        }

        [Test]
        public void Utility_ServerOpenServiceGoodExample()
        {
            PowerPrice_Server server = new PowerPrice_Server();
            Assert.DoesNotThrow(() => server.Open());
        }

        [Test]
        public void Utility_ServerCloseServiceGoodExample()
        {
            PowerPrice_Server server = new PowerPrice_Server();
            server.Open();

            Assert.DoesNotThrow(() => server.Close());
        }
    }
}
