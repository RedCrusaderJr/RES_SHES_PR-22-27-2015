using System;
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
    class MeasurementTest
    {
        [Test]
        public void MeasurementDay_PropertyTest()
        {
            int day_num = 12;
            Measurement m = new Measurement();
            m.Day = day_num;

            Assert.AreEqual(m.Day, day_num);
        }


        [Test]
        public void MeasurementHourOfTheDay_PropertyTest()
        {
            double hour_num = 17;
            Measurement m = new Measurement();
            m.HourOfTheDay = hour_num;

            Assert.AreEqual(m.HourOfTheDay, Math.Round(hour_num, 2));
        }


        [Test]
        public void MeasurementTotalConsumption_PropertyTest()
        {
            double consumer_cons = 10;
            double battery_cons = 20;

            Measurement m = new Measurement();
            m.ConsumersConsumption = consumer_cons;
            m.BatteryConsumption = battery_cons;

            Assert.AreEqual(m.TotalConsumption, Math.Round(consumer_cons + battery_cons, 3));
        }


        [Test]
        public void MeasurementConsumerConsumption_PropertyTest()
        {
            double consumer_cons = 10;
            Measurement m = new Measurement();
            m.ConsumersConsumption = consumer_cons;

            Assert.AreEqual(m.ConsumersConsumption, Math.Round(consumer_cons, 3));
        }

        [Test]
        public void MeasurementBatteryConsumption_PropertyTest()
        {
            double battery_cons = 20;
            Measurement m = new Measurement();
            m.BatteryConsumption = battery_cons;

            Assert.AreEqual(m.BatteryConsumption, Math.Round(battery_cons, 3));
        }


        [Test]
        public void MeasurementTotalProduction_PropertyTest()
        {
            double sp_prod = 10;
            double battery_prod = 20;

            Measurement m = new Measurement();
            m.SolarPanelProduction = sp_prod;
            m.BatteryProduction = battery_prod;

            Assert.AreEqual(m.TotalProduction, Math.Round(sp_prod + battery_prod, 3));
        }

        [Test]
        public void MeasurementSolarPanelProduction_PropertyTest()
        {
            double sp_prod = 10;
            Measurement m = new Measurement();
            m.SolarPanelProduction = sp_prod;

            Assert.AreEqual(m.SolarPanelProduction, Math.Round(sp_prod, 3));
        }


        [Test]
        public void MeasurementBatteryProduction_PropertyTest()
        {
            double battery_prod = 20;
            Measurement m = new Measurement();
            m.BatteryProduction = battery_prod;

            Assert.AreEqual(m.BatteryProduction, Math.Round(battery_prod, 3));
        }


        [Test]
        public void MeasurementPowerPrice_PropertyTest()
        {
            double power_price = 2.7;
            Measurement m = new Measurement();
            m.PowerPrice = power_price;

            Assert.AreEqual(m.PowerPrice, Math.Round(power_price, 3));
        }


        [Test]
        public void MeasurementBatteryBalance_PropertyTest()
        {
            double battery_prod = 15;
            double battery_cons = 25;

            Measurement m = new Measurement();
            m.BatteryProduction = battery_prod;
            m.BatteryConsumption = battery_cons;

            Assert.AreEqual(m.BatteryBalance, Math.Round(battery_prod - battery_cons, 3));
        }


        [Test]
        public void MeasurementTotalPowerBalance_PropertyTest()
        {
            double sp_prod = 10;
            double battery_prod = 20;
            double consumer_cons = 12;
            double battery_cons = 29;

            Measurement m = new Measurement();
            m.SolarPanelProduction = sp_prod;
            m.BatteryProduction = battery_prod;
            m.ConsumersConsumption = consumer_cons;
            m.BatteryConsumption = battery_cons;

            Assert.AreEqual(m.TotalPowerBalance, Math.Round(sp_prod + battery_prod - (consumer_cons + battery_cons), 3));
        }


        [Test]
        public void MeasurementTotalPowerBalancePrice_PropertyTest()
        {
            double sp_prod = 10;
            double battery_prod = 20;
            double consumer_cons = 12;
            double battery_cons = 29;
            double power_price = 2.7;

            Measurement m = new Measurement();
            m.SolarPanelProduction = sp_prod;
            m.BatteryProduction = battery_prod;
            m.ConsumersConsumption = consumer_cons;
            m.BatteryConsumption = battery_cons;
            m.PowerPrice = power_price;

            Assert.AreEqual(m.TotalPowerBalancePrice, Math.Round((sp_prod + battery_prod - (consumer_cons + battery_cons)) * power_price, 3));
        }


        [Test]
        public void MeasurementPowerFromUtility_PropertyTest()
        {
            double sp_prod = 10;
            double battery_prod = 20;
            double consumer_cons = 12;
            double battery_cons = 29;

            Measurement m = new Measurement();
            m.SolarPanelProduction = sp_prod;
            m.BatteryProduction = battery_prod;
            m.ConsumersConsumption = consumer_cons;
            m.BatteryConsumption = battery_cons;

            if((sp_prod + battery_prod - consumer_cons - battery_cons) < 0)
            {
                Assert.AreEqual(m.PowerFromUtility, Math.Round(-(sp_prod + battery_prod - consumer_cons - battery_cons), 3));
            }
            else
            {
                Assert.AreEqual(m.PowerFromUtility, 0);
            }
        }


        [Test]
        public void MeasurementPowerToUtility_PropertyTest()
        {
            double sp_prod = 10;
            double battery_prod = 20;
            double consumer_cons = 12;
            double battery_cons = 29;

            Measurement m = new Measurement();
            m.SolarPanelProduction = sp_prod;
            m.BatteryProduction = battery_prod;
            m.ConsumersConsumption = consumer_cons;
            m.BatteryConsumption = battery_cons;

            if ((sp_prod + battery_prod - consumer_cons - battery_cons) > 0)
            {
                Assert.AreEqual(m.PowerToUtility, Math.Round(sp_prod + battery_prod - consumer_cons - battery_cons, 3));
            }
            else
            {
                Assert.AreEqual(m.PowerToUtility, 0);
            }
        }


        [Test]
        public void MeasurementMoneyBalance_PropertyTest()
        {
            double sp_prod = 10;
            double battery_prod = 20;
            double consumer_cons = 12;
            double battery_cons = 29;
            double power_price = 2.7;

            Measurement m = new Measurement();
            m.SolarPanelProduction = sp_prod;
            m.BatteryProduction = battery_prod;
            m.ConsumersConsumption = consumer_cons;
            m.BatteryConsumption = battery_cons;
            m.PowerPrice = power_price;


            double total_power_balance = sp_prod + battery_prod - consumer_cons - battery_cons;
            double power_from_utility;
            double power_to_utility;


            if(total_power_balance < 0)
            {
                power_from_utility = -total_power_balance;
            }
            else
            {
                power_from_utility = 0;
            }


            if(total_power_balance > 0)
            {
                power_to_utility = total_power_balance;
            }
            else
            {
                power_to_utility = 0;
            }


            Assert.AreEqual(m.MoneyBalance, power_to_utility * power_price - power_from_utility * power_price);
        }
    }
}
