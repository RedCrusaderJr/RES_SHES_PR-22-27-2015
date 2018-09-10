using Common;
using SHES.Data.Access;
using SHES.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{
    public class MenuFunctions
    {
        public static void StartDriving(ElectricVehicleCharger evc, double drinigHours)
        {
            if (evc.OnCharger)
            {
                evc.OnCharger = false;
            }

            Task.Run(() => Driving(evc, drinigHours));
        }

        private static void Driving(ElectricVehicleCharger evc, double drivingHours)
        {
            double drivingMinutes = drivingHours * 60;

            do
            {
                DBManager.S_Instance.GetSingleElectricVehicleCharger(evc.BatteryID);
                double capacityChange = evc.CurrentCapacity * 60 - 1;
                evc.CurrentCapacity = capacityChange / 60;
                DBManager.S_Instance.UpdateElecticVehicleCharger(evc);
                drivingMinutes--;
                Thread.Sleep(Constants.MINUTE);
            }
            while (drivingMinutes > 0);
        }
    }
}
