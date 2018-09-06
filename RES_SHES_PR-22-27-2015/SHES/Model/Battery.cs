using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Model
{

    public class Battery
    {
        [Key]
        public string BatteryID { get; set; }
        public double MaxPower { get; set; }
        public double MaxCapacity { get; set; }
        public double Capacity { get; set; }
        public EMode Mode { get; set; }
    }
}
