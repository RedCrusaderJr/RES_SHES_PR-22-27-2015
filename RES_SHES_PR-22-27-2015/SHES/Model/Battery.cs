using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Model
{
    public enum BatteryMode { CHARGING, NOT_CHARGING, NONE };

    public class Battery
    {
        [Key]
        public string BatteryID { get; set; }
        public double MaxPower { get; set; }
        public double Capacity { get; set; }
        public BatteryMode Mode { get; set; }
    }
}
