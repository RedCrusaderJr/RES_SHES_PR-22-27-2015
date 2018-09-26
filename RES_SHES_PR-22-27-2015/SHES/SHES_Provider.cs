using Common;
using SHES.Data.Model;
using SHES.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace SHES
{
    class SHES_Provider : ISHES
    {
        public List<Dictionary<String, Double>> GetInfoForDate(string date)
        {
            Dictionary<Double, IMeasurement> measurementsForDay = DBManager.S_Instance.GetAllMeasurementsBySpecificDay(int.Parse(date.Split('.')[0]));

            Dictionary<String, Double> solarPanelProduction = SolarPanelProductionConvertion(measurementsForDay);
            Dictionary<String, Double> batteryConsumptionProduction = BatteryConsumptionProductionConvertion(measurementsForDay);
            Dictionary<String, Double> powerFromUtility = PowerFromUtilityConvertion(measurementsForDay);
            Dictionary<String, Double> totalConsumption = TotalConsumptionConvertion(measurementsForDay);
            Dictionary<String, Double> powerPrice = PowerPriceConvertion(measurementsForDay);

            List<Dictionary<String, Double>> listOfInfoForDay = new List<Dictionary<String, Double>>
            {
                solarPanelProduction,
                batteryConsumptionProduction,
                powerFromUtility,
                totalConsumption,
                powerPrice
            };

            return listOfInfoForDay;
        }

        private String TotalHoursToString(Double totalHours)
        {
            Int32 totalMinutes = (Int32)(totalHours * Constants.MINUTES_IN_HOUR);
            TimeSpan ts = TimeSpan.FromMinutes(totalMinutes);
            return String.Format($"{ts.Hours} : {ts.Minutes}");
        }

        private Dictionary<String, Double> SolarPanelProductionConvertion(Dictionary<Double, IMeasurement> measurementsForDay)
        {
            Dictionary<String, Double> solarPanelProductionInfo = new Dictionary<string, double>();

            foreach (KeyValuePair<Double, IMeasurement> kvp in measurementsForDay)
            {
                String time = TotalHoursToString(kvp.Key);

                if (!solarPanelProductionInfo.ContainsKey(time))
                {
                    solarPanelProductionInfo.Add(time, kvp.Value.SolarPanelProduction);
                }
            }

            return solarPanelProductionInfo;
        }

        private Dictionary<String, Double> BatteryConsumptionProductionConvertion(Dictionary<Double, IMeasurement> measurementsForDay)
        {
            Dictionary<String, Double> batteryConsumptionProductionInfo = new Dictionary<string, double>();

            foreach (KeyValuePair<Double, IMeasurement> kvp in measurementsForDay)
            {
                String time = TotalHoursToString(kvp.Key);

                if (!batteryConsumptionProductionInfo.ContainsKey(time))
                {
                    batteryConsumptionProductionInfo.Add(time, kvp.Value.BatteryBalance);
                }
            }

            return batteryConsumptionProductionInfo;
        }

        private Dictionary<String, Double> PowerFromUtilityConvertion(Dictionary<Double, IMeasurement> measurementsForDay)
        {
            Dictionary<String, Double> powerFromUtilityInfo = new Dictionary<string, double>();

            foreach (KeyValuePair<Double, IMeasurement> kvp in measurementsForDay)
            {
                String time = TotalHoursToString(kvp.Key);

                if (!powerFromUtilityInfo.ContainsKey(time))
                {
                    powerFromUtilityInfo.Add(time, kvp.Value.PowerFromUtility);
                }
            }

            return powerFromUtilityInfo;
        }

        private Dictionary<String, Double> TotalConsumptionConvertion(Dictionary<Double, IMeasurement> measurementsForDay)
        {
            Dictionary<String, Double> totalConsumptionInfo = new Dictionary<string, double>();

            foreach (KeyValuePair<Double, IMeasurement> kvp in measurementsForDay)
            {
                String time = TotalHoursToString(kvp.Key);

                if (!totalConsumptionInfo.ContainsKey(time))
                {
                    totalConsumptionInfo.Add(time, kvp.Value.TotalConsumption);
                }
            }

            return totalConsumptionInfo;
        }

        private Dictionary<String, Double> PowerPriceConvertion(Dictionary<Double, IMeasurement> measurementsForDay)
        {
            Dictionary<String, Double> powerPriceInfo = new Dictionary<string, double>();

            foreach (KeyValuePair<Double, IMeasurement> kvp in measurementsForDay)
            {
                String time = TotalHoursToString(kvp.Key);

                if (!powerPriceInfo.ContainsKey(time))
                {
                    powerPriceInfo.Add(time, kvp.Value.PowerPrice);
                }
            }

            return powerPriceInfo;
        }
    }
}
