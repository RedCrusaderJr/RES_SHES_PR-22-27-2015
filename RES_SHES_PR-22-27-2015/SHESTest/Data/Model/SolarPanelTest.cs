using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;
using SHES.Data.Model;
using Moq;


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

        [Test]
        public void SolarPanelCalculatePower_GoodExample(string id)
        {
            SolarPanel sp = new SolarPanel()
            {
                MaxPower = 1,
            };

            double result1 = sp.CalculatePower(_proxy1, _hourOfTheDay1);
            double result2 = sp.CalculatePower(_proxy2, _hourOfTheDay2);

            Assert.AreEqual(result1, (sp.MaxPower * _proxy1.GetSunlightPercentage(_hourOfTheDay1) / 100));
            Assert.AreEqual(result2, (sp.MaxPower * _proxy2.GetSunlightPercentage(_hourOfTheDay2) / 100));
        }

        private IWeatherForecast _proxy1;
        private IWeatherForecast _proxy2;
        private double _hourOfTheDay1 = 5.5;
        private double _hourOfTheDay2 = 13.00;

        [SetUp]
        public void SetUp()
        {
            var moq = new Mock<IWeatherForecast>();
            moq.Setup(wf => wf.GetSunlightPercentage(_hourOfTheDay1)).Returns(() =>
            {
                //TODO po weather provider metodama
                return 0; //return 0 da vs ne bi prijavljivao gresku na ovoj liniji
            });
            _proxy1 = moq.Object;

            var moq2 = new Mock<IWeatherForecast>();
            moq2.Setup(o => o.GetSunlightPercentage(_hourOfTheDay2)).Returns( () =>
            {
                //TODO po weather provider metodama
                return 0; //return 0 da vs ne bi prijavljivao gresku na ovoj liniji
            });
            _proxy2 = moq2.Object;
        }
        // TODO

        // kako da testiram konstruktor sa taskom
    }
}
