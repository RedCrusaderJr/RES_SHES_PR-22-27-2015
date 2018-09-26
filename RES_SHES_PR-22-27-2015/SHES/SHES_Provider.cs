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
            List<KeyValuePair<Double, IMeasurement>> sortedMeasurements = measurementsForDay.ToList();
            sortedMeasurements = sortedMeasurements.OrderBy(sm => sm.Key).ToList();

            sortedMeasurements = Discretize(sortedMeasurements);

            Dictionary <String, Double> solarPanelProduction = SolarPanelProductionConvertion(sortedMeasurements);
            Dictionary<String, Double> batteryConsumptionProduction = BatteryConsumptionProductionConvertion(sortedMeasurements);
            Dictionary<String, Double> powerFromUtility = PowerFromUtilityConvertion(sortedMeasurements);
            Dictionary<String, Double> totalConsumption = TotalConsumptionConvertion(sortedMeasurements);
            Dictionary<String, Double> powerPrice = PowerPriceConvertion(sortedMeasurements);

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

        private List<KeyValuePair<double, IMeasurement>> Discretize(List<KeyValuePair<double, IMeasurement>> sortedMeasurements)
        {
            List<KeyValuePair<double, IMeasurement>> discretizedList = new List<KeyValuePair<double, IMeasurement>>();

            discretizedList.Add(sortedMeasurements[0]);
            double lastKeyValue = sortedMeasurements[0].Key;
            foreach(KeyValuePair<double,IMeasurement> kvp in sortedMeasurements)
            {
                if(kvp.Key >= lastKeyValue+1)
                {
                    discretizedList.Add(kvp);
                    lastKeyValue = kvp.Key;
                }
            }

            return discretizedList;
        }

        private String TotalHoursToString(Double totalHours)
        {
            Int32 totalMinutes = (Int32)(totalHours * Constants.MINUTES_IN_HOUR);
            TimeSpan ts = TimeSpan.FromMinutes(totalMinutes);
            return String.Format($"{ts.Hours} : {ts.Minutes}");
        }

        private Dictionary<String, Double> SolarPanelProductionConvertion(List<KeyValuePair<Double, IMeasurement>> measurementsForDay)
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

        private Dictionary<String, Double> BatteryConsumptionProductionConvertion(List<KeyValuePair<Double, IMeasurement>> measurementsForDay)
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

        private Dictionary<String, Double> PowerFromUtilityConvertion(List<KeyValuePair<Double, IMeasurement>> measurementsForDay)
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

        private Dictionary<String, Double> TotalConsumptionConvertion(List<KeyValuePair<Double, IMeasurement>> measurementsForDay)
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

        private Dictionary<String, Double> PowerPriceConvertion(List<KeyValuePair<Double, IMeasurement>> measurementsForDay)
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
