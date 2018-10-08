using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;
using System.ServiceModel;
using SHES;

namespace SHESTest
{
    [TestFixture]
    class SHES_ServerTest
    {
        [Test]
        public void SHES_ServerConstructorGoodExample()
        {
            SHES_Server server = new SHES_Server();

            Assert.AreEqual(server._serviceHost.State, CommunicationState.Created);
        }


        [Test]
        public void SHES_ServerOpenServiceGoodExample()
        {
            SHES_Server server = new SHES_Server();
            Assert.DoesNotThrow(() => server.Open());
        }


        [Test]
        public void SHES_ServerCloseServiceGoodExample()
        {
            SHES_Server server = new SHES_Server();
            server.Open();

            Assert.DoesNotThrow(() => server.Close());
        }
    }
}
