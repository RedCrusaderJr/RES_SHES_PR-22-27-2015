using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.IModel
{
    public interface IMeasurement : INotifyPropertyChanged
    {
        String MesurementID { get; }
        Int32 Day { get; set; }
        Double HourOfTheDay { get; set; }

        Double TotalConsumption { get; }
        Double ConsumersConsumption { get; set; }
        Double BatteryConsumption { get; set; }

        Double TotalProduction { get; }
        Double SolarPanelProduction { get; set; }
        Double BatteryProduction { get; set; }

        Double PowerPrice { get; set; }
        Double BatteryBalance { get; }
        Double TotalPowerBalance { get; }
        Double TotalPowerBalancePrice { get; }

        Double PowerFromUtility { get; }
        Double PowerToUtility { get; }
        Double MoneyBalance { get; }
    }
}
