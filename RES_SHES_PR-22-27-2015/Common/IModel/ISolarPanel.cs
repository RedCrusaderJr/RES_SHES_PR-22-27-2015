using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.IModel
{
    public interface ISolarPanel
    {
        
        string SolarPanelID { get; set; }
        double MaxPower { get; set; }
        double CurrentPower { get; }

        double CalculatePower(IWeatherForecast proxy, double hourOfTheDay);
        void StartTask();
    }
}
