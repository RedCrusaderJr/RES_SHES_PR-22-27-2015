using Common;
using Common.IModel;
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
    public class SolarPanel : ISolarPanel
    {
        [Key]
        public string SolarPanelID { get; set; }
        public double MaxPower { get; set; }
        public double CurrentPower { get; private set; }
        
        public SolarPanel() { }

        public SolarPanel(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID cannot be null!");
            }

            if (id == "")
            {
                throw new ArgumentException("ID cannot be empty!");
            }

            SolarPanelID = id;
        }

        public SolarPanel(SolarPanel sp, Task solarTask)
        {
            SolarPanelID = sp.SolarPanelID;
            MaxPower = sp.MaxPower;
            StartTask();
        }

        public double CalculatePower(IWeatherForecast proxy, double hourOfTheDay)
        {
            return (MaxPower * proxy.GetSunlightPercentage(hourOfTheDay) / 100);
        }

        public void StartTask()
        {
            Task.Run(() =>
            {
                CurrentPower = CalculatePower(ConnectHelper.ConnectWeatherForecast(), ConnectHelper.ConnectUniversalClock().GetTimeInHours());
                DBManager.S_Instance.UpdateSolarPanel(this);
            });
        }
    }
}
