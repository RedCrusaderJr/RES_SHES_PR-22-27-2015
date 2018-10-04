using Common;
using SHES.Data.Model;
using SHES.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{
    //TODO: Testirati
    public class MenuFunctions
    {
        public static void StartDriving(ElectricVehicleCharger evc, double drinigHours)
        {
            if (evc.OnCharger)
            {
                evc.OnCharger = false;
                DBManager.S_Instance.UpdateElecticVehicleCharger(evc);
            }

            Task.Run(() => Driving(evc, drinigHours));
        }

        private static void Driving(ElectricVehicleCharger evc, double drivingHours)
        {
            double drivingMinutes = drivingHours * Constants.MINUTES_IN_HOUR;

            do
            {
                DBManager.S_Instance.GetSingleElectricVehicleCharger(evc.BatteryID);
                double capacityChange = evc.CurrentCapacity * Constants.MINUTES_IN_HOUR - 1;
                evc.CurrentCapacity = Math.Round(capacityChange / Constants.MINUTES_IN_HOUR, 2);
                DBManager.S_Instance.UpdateElecticVehicleCharger(evc);
                drivingMinutes--;
                Thread.Sleep(Constants.MILISECONDS_IN_MINUTE);
            }
            while (drivingMinutes > 0);
        }

        public static void ShowReport()
        {
            // iscrtaj grafik sa 4 krive
            //
            //      proizvodnja panela
            //      energija iz baterija (+ / -)
            //      uvoz iz utility-a (+ / -)
            //      ukupna potrosnja
        }

        public static void ShowFinancialState()
        {
            // prikazi trenutnu vrednost promenljive KASA (?)
        }

        public static void ConnectEVC(ElectricVehicleCharger evc)
        {
            evc.OnCharger = true;
            DBManager.S_Instance.UpdateElecticVehicleCharger(evc);
        }

        public static void DisconnectEVC(ElectricVehicleCharger evc)
        {
            evc.OnCharger = false;
            DBManager.S_Instance.UpdateElecticVehicleCharger(evc);
        }

        public static void StartCharging(ElectricVehicleCharger evc)
        {
            evc.Mode = EMode.CONSUMING;
            DBManager.S_Instance.UpdateElecticVehicleCharger(evc);
        }

        public static void StopCharging(ElectricVehicleCharger evc)
        {
            evc.Mode = EMode.NONE;
            DBManager.S_Instance.UpdateElecticVehicleCharger(evc);
        }
    }
}
