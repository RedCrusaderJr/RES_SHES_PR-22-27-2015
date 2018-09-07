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

        public ElectricVehicleCharger() : base() { }

        public ElectricVehicleCharger(string id) : base(id) { }

        public ElectricVehicleCharger(ElectricVehicleCharger evc) : base(evc)
        {
            OnCharger = evc.OnCharger;
            Activity = evc.Activity;
        }
    }
}
