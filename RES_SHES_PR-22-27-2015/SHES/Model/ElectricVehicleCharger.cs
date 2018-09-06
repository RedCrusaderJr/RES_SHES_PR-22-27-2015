using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Model
{
    public class ElectricVehicleCharger : Battery
    {
        public bool OnCharger { get; set; }
        public bool Activity { get; set; }
    }
}
