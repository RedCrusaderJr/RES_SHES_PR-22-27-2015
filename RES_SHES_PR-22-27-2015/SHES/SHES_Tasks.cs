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
    class SHES_Tasks
    {
        public static void BatteryBehavior()
        {
            Double hourOfTheDay;

            while (true)
            { 
                Dictionary<string, Battery> batteries = DBManager.S_Instance.GetAllBatteries();
                hourOfTheDay = UniversalClock.S_Instance.TimeHours;

                if(hourOfTheDay >= 3 && hourOfTheDay <= 6)
                {
                    // punjenje

                    foreach(Battery b in batteries.Values)
                    {
                        b.Consuming();
                    }
                }
                else if(hourOfTheDay >= 14 && hourOfTheDay <= 17)
                {
                    // praznjenje

                    foreach(Battery b in batteries.Values)
                    {
                        b.Generating();
                    }
                }
                else
                {
                    foreach(Battery b in batteries.Values)
                    {
                        b.Mode = EMode.NONE;
                    }
                }


                foreach(Battery b in batteries.Values)
                {
                    DBManager.S_Instance.UpdateBattery(b);
                }

                Thread.Sleep(Constants.MILISECONDS_IN_MINUTE);
            }
        }

        public static void MainCalculus()
        {
            while (true)
            {
                IPowerPrice proxy = ConnectUtility();

                Measurement currentMeasurement = new Measurement
                {
                    Consumption = 0,
                    Production = 0,
                };

                // dobavljanje svih elemenata

                Dictionary<string, Battery> batteries = DBManager.S_Instance.GetAllBatteries();
                Dictionary<string, ElectricVehicleCharger> evcs = DBManager.S_Instance.GetAllElectricVehicleChargers();
                Dictionary<string, SolarPanel> sps = DBManager.S_Instance.GetAllSolarPanels();
                Dictionary<string, Consumer> consumers = DBManager.S_Instance.GetAllConsumers();


                // racunanje zahtevane energije - currentConsuming

                foreach(Battery b in batteries.Values)
                {
                    if(b.Mode == EMode.CONSUMING)
                    {
                        currentMeasurement.Consumption += b.MaxPower;
                    }
                }

                foreach(ElectricVehicleCharger evc in evcs.Values)
                {
                    if(evc.OnCharger && evc.Mode == EMode.CONSUMING)
                    {
                        currentMeasurement.Consumption += evc.MaxPower;
                    }
                }

                foreach(Consumer c in consumers.Values)
                {
                    if(c.IsConsuming)
                    {
                        currentMeasurement.Consumption += c.Consumption;
                    }
                }



                // racunanje proizvedene energije - currentGenerating

                foreach(Battery b in batteries.Values)
                {
                    if(b.Mode == EMode.GENERATING)
                    {
                        currentMeasurement.Production += b.MaxPower;
                    }
                }

                foreach(ElectricVehicleCharger evc in evcs.Values)
                {
                    if(evc.Mode == EMode.GENERATING)
                    {
                        currentMeasurement.Production += evc.MaxPower;
                    }
                }

                foreach(SolarPanel sp in sps.Values)
                {
                    currentMeasurement.Production += sp.CalculatePower();
                }

                currentMeasurement.PowerPrice = proxy.GetPowerPrice();
                currentMeasurement.Day = UniversalClock.S_Instance.TimeDay;
                currentMeasurement.HourOfTheDay = UniversalClock.S_Instance.TimeHours;                

                Console.WriteLine($"BalanceOfEnergy: {currentMeasurement.Balance}  Price[1 kWh]: {currentMeasurement.PowerPrice}");
                Console.WriteLine($"Balans price: {currentMeasurement.BalancePrice}");
                Console.WriteLine();

                DBManager.S_Instance.AddMeasurement(currentMeasurement);

                Thread.Sleep(Constants.MILISECONDS_IN_MINUTE);
            }
        }

        static IPowerPrice ConnectUtility()
        {
            NetTcpBinding binding = new NetTcpBinding();

            return new ChannelFactory<IPowerPrice>(binding, new EndpointAddress("net.tcp://localhost:6002/Utility")).CreateChannel();
        }
    }
}
