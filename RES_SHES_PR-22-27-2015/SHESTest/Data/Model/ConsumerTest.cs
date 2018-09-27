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
    class ConsumerTest
    {
        [Test]
        [TestCase("abc")]
        [TestCase("xxx")]
        public void ConsumerConstructor_GoodExample(string id)
        {
            Consumer c = new Consumer(id);

            Assert.AreEqual(c.ConsumerID, id);
        }

        [Test]
        [TestCase("")]
        public void ConsumerConstructor_BadExample1(string id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Consumer c = new Consumer(id);
            }
            );
        }

        [Test]
        [TestCase(null)]
        public void ConsumerConstructor_BadExample2(string id)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Consumer c = new Consumer(id);
            }
            );
        }

        [Test]
        [TestCase(null)]
        public void ConsumerConstructor2_BadExample(Consumer c)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Consumer new_consumer = new Consumer(c);
            }
            );
        }
    }
}
