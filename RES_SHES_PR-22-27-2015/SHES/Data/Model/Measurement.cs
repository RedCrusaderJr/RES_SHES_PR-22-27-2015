using Common.IModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    [DataContract]
    //TODO: fali TEST!
    public class Measurement : IMeasurement
    {
        private double _hourOfTheDay;

        private double _consumersConsumption;
        private double _batteryConsumption;

        private double _solarPanelProduction;
        private double _batteryProduction;

        private double _powerPrice;
        
        [Key]
        [DataMember]
        public string MesurementID { get; private set; }
        [Required]
        [DataMember]
        public Int32 Day { get; set; }
        [Required]
        [DataMember]
        public Double HourOfTheDay
        {
            get => Math.Round(_hourOfTheDay, 2);
            set => _hourOfTheDay = value;
        }

        [DataMember]
        public Double TotalConsumption
        {
            get => Math.Round(ConsumersConsumption + BatteryConsumption, 3);
        }
        [DataMember]
        public Double ConsumersConsumption
        {
            get => Math.Round(_consumersConsumption, 3);
            set => _consumersConsumption = value;
        }
        [DataMember]
        public Double BatteryConsumption
        {
            get => Math.Round(_batteryConsumption, 3);
            set => _batteryConsumption = value;
        }

        [DataMember]
        public Double TotalProduction
        {
            get => Math.Round(SolarPanelProduction + BatteryProduction, 3);
        }
        [DataMember]
        public Double SolarPanelProduction
        {
            get => Math.Round(_solarPanelProduction, 3);
            set => _solarPanelProduction = value;
        }
        [DataMember]
        public Double BatteryProduction
        {
            get => Math.Round(_batteryProduction, 3);
            set => _batteryProduction = value;
        }

        [DataMember]
        public Double PowerPrice
        {
            get => Math.Round(_powerPrice, 3);
            set => _powerPrice = value;
        }
        [DataMember]
        public Double BatteryBalance
        {
            get => Math.Round(BatteryProduction - BatteryConsumption, 3);
        }
        [DataMember]
        public Double TotalPowerBalance
        {
            get => Math.Round(TotalProduction - TotalConsumption, 3);
        }
        [DataMember]
        public Double TotalPowerBalancePrice
        {
            get => Math.Round(TotalPowerBalance * PowerPrice, 3);
        }

        [DataMember]
        public Double PowerFromUtility
        {
            get => TotalPowerBalance < 0 ? -TotalPowerBalance : 0;
        }
        [DataMember]
        public Double PowerToUtility
        {
            get => TotalPowerBalance > 0 ? TotalPowerBalance : 0;
        }
        [DataMember]
        public Double MoneyBalance
        {
            get => PowerToUtility * PowerPrice - PowerFromUtility * PowerPrice;
        }


        public Measurement()
        {
            MesurementID = this.GetHashCode().ToString();
        }

        #region INotifyPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string parameter)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter));

        }
        #endregion

    }
}
