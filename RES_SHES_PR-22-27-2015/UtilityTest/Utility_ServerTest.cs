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
    class Utility_ServerTest
    {
        [Test]
        public void Utility_ServerConstructorGoodExample()
        {
            Utility_Server server = new Utility.Utility_Server();

            Assert.AreEqual(server.ServiceHost.State, CommunicationState.Created);
            Assert.AreEqual(server.ServiceHost.Extensions.Count, 1);
        }

        [Test]
        public void Utility_ServerOpenServiceGoodExample()
        {
            Utility_Server server = new Utility_Server();
            Assert.DoesNotThrow(() => server.Open());
        }

        [Test]
        public void Utility_ServerCloseServiceGoodExample()
        {
            Utility_Server server = new Utility_Server();
            server.Open();

            Assert.DoesNotThrow(() => server.Close());
        }
    }
}
