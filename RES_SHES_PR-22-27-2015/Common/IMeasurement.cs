using System;
using System.ComponentModel;

namespace Common.Model
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