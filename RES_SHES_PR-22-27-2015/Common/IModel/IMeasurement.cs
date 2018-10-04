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
        Double TotalProduction { get; }
        Double TotalBalance { get; }
        Double TotalBalancePrice { get; }

        Double SolarPanelProduction { get; set; }

        Double BatteryBalance { get; }
        Double BatteryConsumption { get; set; }

        Double BatteryProduction { get; set; }
        Double ConsumersConsumption { get; set; }

        Double PowerFromUtility { get; }
        Double PowerPrice { get; set; }
    }
}
