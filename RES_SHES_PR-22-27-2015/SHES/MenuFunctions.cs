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
                evc.CurrentCapacity = Math.Round(capacityChange / 60, 2);
                DBManager.S_Instance.UpdateElecticVehicleCharger(evc);
                drivingMinutes--;
                Thread.Sleep(Constants.MINUTE);
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

        }

        public static void DisconnectEVC(ElectricVehicleCharger evc)
        {

        }

        public static void StartCharging(ElectricVehicleCharger evc)
        {

        }

        public static void StopCharging(ElectricVehicleCharger evc)
        {

        }
    }
}
