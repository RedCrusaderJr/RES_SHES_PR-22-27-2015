using Common;
using SHES.Data.Access;
using SHES.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{
    // TODO: testovi
    // Dunja: nema testiranja - sve metode su *static*
    class SHES_Tasks
    {
        public static void BatteryBehavior()
        {
            Double hourOfTheDay;

            int iterationStart = ConnectHelper.ConnectUniversalClock().GetTimeInMinutes();
            while (true)
            {
                int currentMoment = ConnectHelper.ConnectUniversalClock().GetTimeInMinutes();
                if (currentMoment - iterationStart >= 1)
                {
                    iterationStart = currentMoment;
                }
                else
                {
                    continue;
                }

                Dictionary<string, Battery> batteries = DBManager.S_Instance.GetAllBatteries();
                hourOfTheDay = ConnectHelper.ConnectUniversalClock().GetTimeInHours();

                if(hourOfTheDay >= 3 && hourOfTheDay <= 6)
                {
                    batteries = ChargeBatteries(batteries);
                }
                else if(hourOfTheDay >= 14 && hourOfTheDay <= 17)
                {
                    batteries = DischargeBatteries(batteries);
                }
                else
                {
                    foreach(Battery b in batteries.Values)
                    {
                        if(b is ElectricVehicleCharger evc)
                        {
                            if(evc.Mode == EMode.CONSUMING && evc.OnCharger)
                            {
                                evc.Consuming();
                                continue;
                            }
                        }

                        b.Mode = EMode.NONE;
                    }
                }

                foreach(Battery b in batteries.Values)
                {
                    DBManager.S_Instance.UpdateBattery(b);
                }
                //Thread.Sleep(Constants.MILISECONDS_IN_MINUTE);
            }
        }

        private static Dictionary<string, Battery> DischargeBatteries(Dictionary<string, Battery> batteries)
        {
            foreach (Battery b in batteries.Values)
            {
                if (b is ElectricVehicleCharger evc)
                {
                    if (!evc.OnCharger || evc.Mode == EMode.CONSUMING)
                    {
                        continue;
                    }
                }
                b.Generating();
            }
            return batteries;
        }

        private static Dictionary<string, Battery> ChargeBatteries(Dictionary<string, Battery> batteries)
        {
            foreach (Battery b in batteries.Values)
            {
                if (b is ElectricVehicleCharger evc)
                {
                    if (!evc.OnCharger)
                    {
                        continue;
                    }
                }
                b.Consuming();
            }
            return batteries;
        }

        public static void CollectingMeasurements()
        {
            int iterationStart = ConnectHelper.ConnectUniversalClock().GetTimeInMinutes();
            while (true)
            {
                int currentMoment = ConnectHelper.ConnectUniversalClock().GetTimeInMinutes();
                if (currentMoment - iterationStart >= 1)
                {
                    iterationStart = currentMoment;
                }
                else
                {
                    continue;
                }

                IPowerPrice powerPriceProxy = ConnectHelper.ConnectUtility();
                IUniversalClockService universalClockProxy = ConnectHelper.ConnectUniversalClock();

                Measurement currentMeasurement = new Measurement
                {
                    BatteryConsumption = 0,
                    BatteryProduction = 0,
                    ConsumersConsumption = 0,
                    SolarPanelProduction = 0,
                };

                Dictionary<string, Battery> batteries = DBManager.S_Instance.GetAllBatteries();
                Dictionary<string, ElectricVehicleCharger> evcs = DBManager.S_Instance.GetAllElectricVehicleChargers();
                Dictionary<string, SolarPanel> sps = DBManager.S_Instance.GetAllSolarPanels();
                Dictionary<string, Consumer> consumers = DBManager.S_Instance.GetAllConsumers();

                Measurement currentConsumptionMeasurement = CalculateCurrentConsumption(batteries, evcs, consumers);
                currentMeasurement.BatteryConsumption = currentConsumptionMeasurement.BatteryConsumption;
                currentMeasurement.ConsumersConsumption = currentConsumptionMeasurement.ConsumersConsumption;

                Measurement currentProductionMeasurement = CalculateCurrentProduction(batteries, evcs, sps);
                currentMeasurement.SolarPanelProduction = currentProductionMeasurement.SolarPanelProduction;
                currentMeasurement.BatteryProduction = currentMeasurement.BatteryProduction;

                currentMeasurement.PowerPrice = powerPriceProxy.GetPowerPrice(universalClockProxy.GetTimeInHours());
                currentMeasurement.Day = universalClockProxy.GetDay();
                currentMeasurement.HourOfTheDay = universalClockProxy.GetTimeInHours();

                DBManager.S_Instance.AddMeasurement(currentMeasurement);
                //Thread.Sleep(Constants.MILISECONDS_IN_MINUTE);
            }
        }

        private static Measurement CalculateCurrentProduction(Dictionary<string, Battery> batteries, Dictionary<string, ElectricVehicleCharger> evcs, Dictionary<string, SolarPanel> sps)
        {
            Measurement currentMeasurement = new Measurement
            {
                BatteryProduction = 0,
                SolarPanelProduction = 0,
            };

            foreach (Battery b in batteries.Values)
            {
                if (b.Mode == EMode.GENERATING)
                {
                    currentMeasurement.BatteryProduction += b.MaxPower;
                }
            }

            foreach (ElectricVehicleCharger evc in evcs.Values)
            {
                if (evc.Mode == EMode.GENERATING)
                {
                    currentMeasurement.BatteryProduction += evc.MaxPower;
                }
            }

            foreach (SolarPanel sp in sps.Values)
            {
                currentMeasurement.SolarPanelProduction += sp.CurrentPower;
            }

            return currentMeasurement;
        }

        private static Measurement CalculateCurrentConsumption(Dictionary<string, Battery> batteries, Dictionary<string, ElectricVehicleCharger> evcs, Dictionary<string, Consumer> consumers)
        {
            Measurement currentMeasurement = new Measurement
            {
                BatteryConsumption = 0,
                ConsumersConsumption = 0,
            };

            foreach (Battery b in batteries.Values)
            {
                if (b.Mode == EMode.CONSUMING)
                {
                    currentMeasurement.BatteryConsumption += b.MaxPower;
                }
            }

            foreach (ElectricVehicleCharger evc in evcs.Values)
            {
                if (evc.OnCharger && evc.Mode == EMode.CONSUMING)
                {
                    currentMeasurement.BatteryConsumption += evc.MaxPower;
                }
            }

            foreach (Consumer c in consumers.Values)
            {
                if (c.IsConsuming)
                {
                    currentMeasurement.ConsumersConsumption += c.Consumption;
                }
            }

            return currentMeasurement;
        }
    }
}
