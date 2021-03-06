﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;
using SHES.Data.Model;

namespace SHESTest.Data.Model
{
    [TestFixture]
    class BatteryTest
    {
        [Test]
        [TestCase("abc")]
        [TestCase("xxx")]
        public void BatteryConstructor_GoodExample(string id)
        {
            Battery b = new Battery(id);

            Assert.AreEqual(b.BatteryID, id);
        }

        [Test]
        [TestCase("")]
        public void BatteryConstructor_BadExample1(string id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Battery b = new Battery(id);
            }
            );
        }

        [Test]
        [TestCase(null)]
        public void BatteryConstructor_BadExample2(string id)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Battery b = new Battery(id);
            }
            );
        }


        [Test]
        [TestCase(null)]
        public void BatteryConstructor2_BadExample(Battery b)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Battery new_battery = new Battery(b);
            }
            );
        }


        [Test]
        public void BatteryConsuming_GoodExample()
        {
            Battery battery1 = new Battery()
            {
                BatteryID = "a",
                MaxPower = 10,
                MaxCapacity = 20,
                CurrentCapacity = 5,
                Mode = EMode.NONE,
            };

            double startingCapacity = battery1.CurrentCapacity;

            battery1.Consuming();

            if (Math.Round((battery1.CurrentCapacity * 60 + 1) / (double)60, 2) <= battery1.MaxCapacity)
            {
                Assert.AreEqual(Math.Round((startingCapacity * 60 + 1) / (double)60, 2), battery1.CurrentCapacity);
                Assert.AreEqual(battery1.Mode, EMode.CONSUMING);
            }
            else
            {
                Assert.AreEqual(battery1.Mode, EMode.NONE);
            }
        }


        [Test]
        public void BatteryGenerating_GoodExample()
        {
            Battery battery1 = new Battery()
            {
                BatteryID = "a",
                MaxPower = 10,
                MaxCapacity = 20,
                CurrentCapacity = 5,
                Mode = EMode.NONE,
            };

            double startingCapacity = battery1.CurrentCapacity;

            battery1.Generating();

            if (Math.Round((battery1.CurrentCapacity * 60 - 1) / (double)60, 2) >= 0)
            {
                Assert.AreEqual(Math.Round((startingCapacity * 60 - 1) / (double)60, 2), battery1.CurrentCapacity);
                Assert.AreEqual(battery1.Mode, EMode.GENERATING);
            }
            else
            {
                Assert.AreEqual(battery1.Mode, EMode.NONE);
            }
        }
    }
}
