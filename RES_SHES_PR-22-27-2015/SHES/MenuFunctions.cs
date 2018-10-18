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
    // TODO: Testirati
    // Dunja: nema testiranja - sve metode su *static*
    public class MenuFunctions
    {
        public static void StartDriving(ElectricVehicleCharger evc, double drinigHours)
        {
            if (evc.OnCharger)
            {
                DisconnectEVC(evc);
            }

            Task.Run(() => Driving(evc, drinigHours));
        }

        private static void Driving(ElectricVehicleCharger evc, double drivingHours)
        {
            double drivingMinutes = drivingHours * Constants.MINUTES_IN_HOUR;

            int iterationStart = ConnectHelper.ConnectUniversalClock().GetTimeInMinutes();
            int dayStart = ConnectHelper.ConnectUniversalClock().GetDay();
            do
            {
                int currentMoment = ConnectHelper.ConnectUniversalClock().GetTimeInMinutes();
                int currentDay = ConnectHelper.ConnectUniversalClock().GetDay();
                if (currentDay > dayStart || currentMoment - iterationStart >= 1)
                {
                    iterationStart = currentMoment;
                    dayStart = currentDay;
                }
                else
                {
                    continue;
                }

                ElectricVehicleCharger evcFromDb = DBManager.S_Instance.GetSingleElectricVehicleCharger(evc.BatteryID);
                double capacityChange = evcFromDb.CurrentCapacity * Constants.MINUTES_IN_HOUR - 1;
                evcFromDb.CurrentCapacity = Math.Round(capacityChange / Constants.MINUTES_IN_HOUR, 2);
                DBManager.S_Instance.UpdateElecticVehicleCharger(evcFromDb);
                drivingMinutes--;
            }
            while (drivingMinutes > 0);
        }

        //UKLONITI METODU i prepraviti meni shodno izmeni
        public static void ShowReport()
        {
            // iscrtaj grafik sa 4 krive
            //
            //      proizvodnja panela
            //      energija iz baterija (+ / -)
            //      uvoz iz utility-a (+ / -)
            //      ukupna potrosnja
        }

        //UKLONITI METODU i prepraviti meni shodno izmeni
        public static void ShowFinancialState()
        {
            // prikazi trenutnu vrednost promenljive KASA (?)
        }

        public static void ConnectEVC(ElectricVehicleCharger evc)
        {
            ElectricVehicleCharger evcFromDb = DBManager.S_Instance.GetSingleElectricVehicleCharger(evc.BatteryID);
            evcFromDb.OnCharger = true;
            DBManager.S_Instance.UpdateElecticVehicleCharger(evcFromDb);
        }

        public static void DisconnectEVC(ElectricVehicleCharger evc)
        {
            ElectricVehicleCharger evcFromDb = DBManager.S_Instance.GetSingleElectricVehicleCharger(evc.BatteryID);
            evcFromDb.OnCharger = false;
            DBManager.S_Instance.UpdateElecticVehicleCharger(evcFromDb);
        }

        public static void StartCharging(ElectricVehicleCharger evc)
        {
            ElectricVehicleCharger evcFromDb = DBManager.S_Instance.GetSingleElectricVehicleCharger(evc.BatteryID);
            evcFromDb.Mode = EMode.CONSUMING;
            DBManager.S_Instance.UpdateElecticVehicleCharger(evcFromDb);
        }

        public static void StopCharging(ElectricVehicleCharger evc)
        {
            ElectricVehicleCharger evcFromDb = DBManager.S_Instance.GetSingleElectricVehicleCharger(evc.BatteryID);
            evcFromDb.Mode = EMode.NONE;
            DBManager.S_Instance.UpdateElecticVehicleCharger(evcFromDb);
        }
    }
}
