using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    public class ElectricVehicleCharger : Battery
    {
        public bool OnCharger { get; set; }
        public bool Activity { get; set; }
    }
}
