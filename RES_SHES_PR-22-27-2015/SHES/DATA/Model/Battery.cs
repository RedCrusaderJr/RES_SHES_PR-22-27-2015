using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    public class Battery
    {
        [Key]
        public string BatteryID { get; set; }
        public double MaxPower { get; set; }
        public double MaxCapacity { get; set; }
        public double CurrentCapacity { get; set; }
        public bool Activity { get; set; }
        public EMode Mode { get; set; }

        public Battery() { }

        public Battery(string id)
        {
            BatteryID = id;
        }

        public Battery(Battery b)
        {
            BatteryID = b.BatteryID;
            MaxPower = b.MaxPower;
            MaxCapacity = b.MaxCapacity;
            CurrentCapacity = b.CurrentCapacity;
            Activity = b.Activity;
            Mode = b.Mode;
        }
    }
}
