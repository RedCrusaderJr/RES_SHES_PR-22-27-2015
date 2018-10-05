using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UniversalTimer;
using Common;
using System.ServiceModel;


namespace UniversalTimerTest
{
    [TestFixture]
    class UniversalClock_ServerTest
    {
        [Test]
        public void UniversalClock_ServerConstructorGoodExample()
        {
            UniversalClock_Server server = new UniversalClock_Server();

            Assert.AreEqual(server.ServiceHost.State, CommunicationState.Created);
           // Assert.AreEqual(server.ServiceHost.Extensions.Count, 1);
        }

        [Test]
        public void UniversalClock_ServerOpenServiceGoodExample()
        {
            UniversalClock_Server server = new UniversalClock_Server();
            Assert.DoesNotThrow(() => server.Open());
        }

        [Test]
        public void UniversalClock_ServerCloseServiceGoodExample()
        {
            UniversalClock_Server server = new UniversalClock_Server();
            server.Open();

            Assert.DoesNotThrow(() => server.Close());
        }
    }
}
