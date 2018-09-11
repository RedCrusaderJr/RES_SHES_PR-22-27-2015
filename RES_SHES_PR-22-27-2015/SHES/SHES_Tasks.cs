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
            IUniversalTimer proxy = ConnectUniversalTimer();

            while (true)
            {
                Dictionary<string, Battery> batteries = DBManager.S_Instance.GetAllBatteries();
                hourOfTheDay = proxy.GetGlobalTimeInHours();

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

                Thread.Sleep(Common.Constants.MINUTE);
            }
        }


        public static void MainCalculus()
        {
            IPowerPrice proxy = ConnectUtility();

            Double currentConsuming;
            Double currentGenerating;
            Double electricEnergy;
            Double price;
            Double electricEnergyPrice;

            while (true)
            {
                currentConsuming = 0;
                currentGenerating = 0;

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
                        currentConsuming += b.MaxPower;
                    }
                }

                foreach(ElectricVehicleCharger evc in evcs.Values)
                {
                    if(evc.OnCharger && evc.Mode == EMode.CONSUMING)
                    {
                        currentConsuming += evc.MaxPower;
                    }
                }

                foreach(Consumer c in consumers.Values)
                {
                    if(c.IsConsuming)
                    {
                        currentConsuming += c.Consumption;
                    }
                }



                // racunanje proizvedene energije - currentGenerating

                foreach(Battery b in batteries.Values)
                {
                    if(b.Mode == EMode.GENERATING)
                    {
                        currentGenerating += b.MaxPower;
                    }
                }

                foreach(ElectricVehicleCharger evc in evcs.Values)
                {
                    if(evc.Mode == EMode.GENERATING)
                    {
                        currentGenerating += evc.MaxPower;
                    }
                }

                foreach(SolarPanel sp in sps.Values)
                {
                    currentGenerating += sp.CalculatePower();
                }


                electricEnergy = currentGenerating - currentConsuming;

                price = proxy.GetPowerPrice();
                electricEnergyPrice = electricEnergy * price;


                Console.WriteLine($"ElectricEnergy: {electricEnergy}  Price[1 kWh]: {price}");
                Console.WriteLine($"ElectricEnergy price: {electricEnergyPrice}");
                Console.WriteLine();


                Thread.Sleep(Common.Constants.MINUTE);
            }
        }


        static IUniversalTimer ConnectUniversalTimer()
        {
            NetTcpBinding binding = new NetTcpBinding();

            return new ChannelFactory<IUniversalTimer>(binding, new EndpointAddress("net.tcp://localhost:6000/UniversalTimer")).CreateChannel();
        }

        static IPowerPrice ConnectUtility()
        {
            NetTcpBinding binding = new NetTcpBinding();

            return new ChannelFactory<IPowerPrice>(binding, new EndpointAddress("net.tcp://localhost:6001/Utility")).CreateChannel();
        }
    }
}
