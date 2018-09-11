using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    public class Measurement
    {
        private double _hourOfTheDay;
        private double _consumption;
        private double _production;
        private double _powerPrice;       

        [Key]
        public string MesurementID { get; private set; }
        [Required]
        public Int32 Day { get; set; }
        [Required]
        public Double HourOfTheDay { get => Math.Round(_hourOfTheDay, 2); set => _hourOfTheDay = value; }
        public Double Consumption { get => Math.Round(_consumption, 3); set => _consumption = value; }
        public Double Production { get => Math.Round(_production, 3); set => _production = value; }
        public Double PowerPrice { get => Math.Round(_powerPrice, 3); set => _powerPrice = value; }
        public Double Balance { get => Math.Round(Production - Consumption, 3); }
        public Double BalancePrice { get => Math.Round(Balance * PowerPrice, 3); }

        public Measurement()
        {
            MesurementID = this.GetHashCode().ToString();
        }
    }
}
