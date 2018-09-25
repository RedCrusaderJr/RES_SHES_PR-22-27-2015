using Common;
using SHES.Data.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    public class SolarPanel
    {
        [Key]
        public string SolarPanelID { get; set; }
        public double MaxPower { get; set; }
        public double CurrentPower { get; private set; }
        
        public SolarPanel() { }

        public SolarPanel(string id)
        {
            SolarPanelID = id;
        }

        public SolarPanel(SolarPanel sp, Task solarTask)
        {
            SolarPanelID = sp.SolarPanelID;
            MaxPower = sp.MaxPower;
            StartTask();
        }

        private double CalculatePower()
        {
            IWeatherForecast proxy = Connect();
            return (MaxPower * proxy.GetSunlightPercentage() / 100);
        }

        private IWeatherForecast Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();

            return new ChannelFactory<IWeatherForecast>(binding, new EndpointAddress("net.tcp://localhost:6001/WeathetForecast")).CreateChannel();
        }

        public void StartTask()
        {
            Task.Run(() =>
            {
                CurrentPower = CalculatePower();
                DBManager.S_Instance.UpdateSolarPanel(this);
            });
        }
    }
}
