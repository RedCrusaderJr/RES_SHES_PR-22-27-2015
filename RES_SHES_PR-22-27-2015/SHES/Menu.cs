using SHES.Data.Access;
using SHES.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    class Menu
    {
        private Int32 answer1;
        private Int32 answer2;

        public void Display()
        {
            do
            {
                Console.WriteLine("   *** MENU ***   ");
                Console.WriteLine();

                Console.WriteLine("1. Add some element");
                Console.WriteLine("2. Remove some element");
                Console.WriteLine("3. Change consumer's activity");
                Console.WriteLine("4. Change EVC's charging");
                Console.WriteLine("5. Show report (graphic)");
                Console.WriteLine("6. Show financial state");
                Console.WriteLine("7. Drive some car");
                Console.WriteLine("8. EXIT");

                Console.WriteLine();
                Console.WriteLine("Your answer: ");
                Int32.TryParse(Console.ReadLine(), out answer1);

                Console.WriteLine();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine();


                switch (answer1)
                {
                    case 1:
                        {
                            AddSomeElement();
                            break;
                        }

                    case 2:
                        {
                            RemoveSomeElement();
                            break;
                        }

                    case 3:
                        {
                            ChangeConsumerActivity();
                            break;
                        }
                    case 4:
                        {
                            ChangeEVCCharging();
                            break;
                        }
                    case 5:
                        {
                            ShowReport();
                            break;
                        }
                    case 6:
                        {
                            ShowFinancialState();
                            break;
                        }
                    case 7:
                        {
                            DriveCar();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Goodbye !");

                            // TODO: pogasi sve aplikacije, ako moze

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Your answer is NOT VALID !");
                            break;
                        }
                }
            }
            while (answer1 != 8);
        }


        #region Adding

        public void AddSomeElement()
        {
            Console.WriteLine("1) Add Solar panel");
            Console.WriteLine("2) Add Battery");
            Console.WriteLine("3) Add Electric vehicle charger");
            Console.WriteLine("4) Add Consumer");
            Console.WriteLine("5) BACK");

            Console.WriteLine();
            Console.WriteLine("Your answer: ");
            Int32.TryParse(Console.ReadLine(), out answer2);

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();


            switch (answer2)
            {
                case 1:
                    {
                        AddSolarPanel();
                        break;
                    }
                case 2:
                    {
                        AddBattery();
                        break;
                    }
                case 3:
                    {
                        AddEVC();
                        break;
                    }
                case 4:
                    {
                        AddConsumer();
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Your answer is NOT VALID !");
                        break;
                    }
            }
        }



        public void AddSolarPanel()
        {
            SolarPanel sp = new SolarPanel();

            Console.WriteLine("Solar panel ID: ");
            sp.SolarPanelID = Console.ReadLine();

            Console.WriteLine("Solar panel MaxPower: ");
            sp.MaxPower = Double.Parse(Console.ReadLine());

            sp.Mode = Common.EMode.GENERATING;


            if (DBManager.S_Instance.AddSolarPanel(sp))
            {
                Console.WriteLine("Solarpanel added successfully.");
            }
            else
            {
                Console.WriteLine("ID alredy used");
            }
        }

        public void AddBattery()
        {
            Battery b = new Battery();

            Console.WriteLine("Battery ID: ");
            b.BatteryID = Console.ReadLine();

            Console.WriteLine("Battery MaxPower: ");
            b.MaxPower = Double.Parse(Console.ReadLine());

            Console.WriteLine("Batery Capacity: ");
            b.MaxCapacity = Double.Parse(Console.ReadLine());

            b.CurrentCapacity = 0;
            b.Activity = false;
            b.Mode = Common.EMode.NONE;

            if (DBManager.S_Instance.AddBattery(b))
            {
                Console.WriteLine("Battery added successfully.");
            }
            else
            {
                Console.WriteLine("ID alredy used");
            }
        }

        public void AddEVC()
        {
            ElectricVehicleCharger evc = new ElectricVehicleCharger();

            Console.WriteLine("EVC-Battery ID: ");
            evc.BatteryID = Console.ReadLine();

            Console.WriteLine("EVC-Battery MaxPower: ");
            evc.MaxPower = Double.Parse(Console.ReadLine());

            Console.WriteLine("EVC-Batery Capacity: ");
            evc.MaxCapacity = Double.Parse(Console.ReadLine());

            evc.CurrentCapacity = 0;
            evc.Activity = false;
            evc.Mode = Common.EMode.NONE;
            evc.OnCharger = false;

            if (DBManager.S_Instance.AddElecticVehicleCharger(evc))
            {
                Console.WriteLine("EVC added successfully.");
            }
            else
            {
                Console.WriteLine("ID alredy used");
            }
        }

        public void AddConsumer()
        {
            Consumer c = new Consumer();

            Console.WriteLine("Consumer ID: ");
            c.ConsumerID = Console.ReadLine();

            Console.WriteLine("Consumption: ");
            c.Consumption = Double.Parse(Console.ReadLine());

            c.Activity = false;
            c.Mode = Common.EMode.NONE;

            if (DBManager.S_Instance.AddConsumer(c))
            {
                Console.WriteLine("Consumer added successfully.");
            }
            else
            {
                Console.WriteLine("ID alredy used");
            }
        }

        #endregion


        #region Removing

        public void RemoveSomeElement()
        {
            Console.WriteLine("1) Remove Solar panel");
            Console.WriteLine("2) Remove Battery");
            Console.WriteLine("3) Remove Electric vehicle charger");
            Console.WriteLine("4) Remove Consumer");
            Console.WriteLine("5) BACK");

            Console.WriteLine();
            Console.WriteLine("Your answer: ");
            Int32.TryParse(Console.ReadLine(), out answer2);

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();


            switch (answer2)
            {
                case 1:
                    {
                        RemoveSolarPanel();
                        break;
                    }
                case 2:
                    {
                        RemoveBattery();
                        break;
                    }
                case 3:
                    {
                        RemoveEVC();
                        break;
                    }
                case 4:
                    {
                        RemoveConsumer();
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Your answer is NOT VALID !");
                        break;
                    }
            }
        }

        public void RemoveSolarPanel()
        {
            Console.WriteLine("List of solar panels => ");
            Dictionary<string, SolarPanel> solarPanels = DBManager.S_Instance.GetAllSolarPanels();
            solarPanels.Values.ToList().ForEach(s => Console.WriteLine($"ID: {s.SolarPanelID}  MaxPower: {s.MaxPower}  Mode: {s.Mode}"));

            Console.WriteLine("Solar panel ID: ");
            string id = Console.ReadLine();
            
            if(solarPanels.ContainsKey(id))
            {
                if(DBManager.S_Instance.RemoveSolarPanel(solarPanels[id]))
                {
                    Console.WriteLine($"Solar panel ID: {solarPanels[id].SolarPanelID} removed successfully.");
                }
                else
                {
                    Console.WriteLine($"Solar panel ID: {solarPanels[id].SolarPanelID} IS NOT removed.");
                }

            }
            else
            {
                Console.WriteLine("Solar panel with that ID doesn't exist.");
            }
        }

        public void RemoveBattery()
        {
            Console.WriteLine("List of batteries => ");
            Dictionary<string, Battery> batteries = DBManager.S_Instance.GetAllBatteries();
            batteries.Values.ToList().ForEach(b => Console.WriteLine($"ID: {b.BatteryID}  MaxPower: {b.MaxPower}  MaxCapacity: {b.MaxCapacity}  CurrentCapacity: {b.CurrentCapacity}  Activity: {b.Activity}  Mode: {b.Mode}"));

            Console.WriteLine("Battery ID: ");
            string id = Console.ReadLine();

            if (batteries.ContainsKey(id))
            {
                if(DBManager.S_Instance.RemoveBattery(batteries[id]))
                {
                    Console.WriteLine($"Battery ID: {batteries[id].BatteryID} removed successfully.");
                }
                else
                {
                    Console.WriteLine($"Battery ID: {batteries[id].BatteryID} IS NOT removed.");
                }
            }
            else
            {
                Console.WriteLine("Battery with that ID doesn't exist.");
            }
        }

        public void RemoveEVC()
        {
            Console.WriteLine("List of EVCs => ");
            Dictionary<string, ElectricVehicleCharger> evcs = DBManager.S_Instance.GetAllElectricVehicleChargers();
            evcs.Values.ToList().ForEach(b => Console.WriteLine($"ID: {b.BatteryID}  MaxPower: {b.MaxPower}  MaxCapacity: {b.MaxCapacity}  CurrentCapacity: {b.CurrentCapacity}  Activity: {b.Activity}  Mode: {b.Mode}  OnCharger: {b.OnCharger}"));

            Console.WriteLine("EVC-Battery ID: ");
            string id = Console.ReadLine();

            if (evcs.ContainsKey(id))
            {
                if(DBManager.S_Instance.RemoveElectricVehicleCharger(evcs[id]))
                {
                    Console.WriteLine($"EVC ID: {evcs[id].BatteryID} removed successfully.");
                }
                else
                {
                    Console.WriteLine($"EVC ID: {evcs[id].BatteryID} IS NOT removed.");
                }
            }
            else
            {
                Console.WriteLine("EVC with that ID doesn't exist.");
            }
        }

        public void RemoveConsumer()
        {
            Console.WriteLine("List of consumers => ");
            Dictionary<string, Consumer> consumers = DBManager.S_Instance.GetAllConsumers();
            consumers.Values.ToList().ForEach(c => Console.WriteLine($"ID: {c.ConsumerID}  Consumption: {c.Consumption}  Activity: {c.Activity}  Mode: {c.Mode}"));

            Console.WriteLine("Consumer ID: ");
            string id = Console.ReadLine();

            if (consumers.ContainsKey(id))
            {
                if(DBManager.S_Instance.RemoveConsumer(consumers[id]))
                {
                    Console.WriteLine($"Consumer ID: {consumers[id].ConsumerID} removed successfully.");
                }
                else
                {
                    Console.WriteLine($"Consumer ID: {consumers[id].ConsumerID} IS NOT removed.");
                }
            }
            else
            {
                Console.WriteLine("Consumer with that ID doesn't exist.");
            }
        }

        #endregion


        public void ChangeConsumerActivity()
        {
            Dictionary<string, Consumer> consumers = DBManager.S_Instance.GetAllConsumers();
            consumers.Values.ToList().ForEach(c => Console.WriteLine($"ID: {c.ConsumerID}  Consumption: {c.Consumption}  Mode: {c.Mode}  Activity: {c.Activity}"));

            Console.WriteLine();
            Console.WriteLine("Consumer ID: ");
            string id = Console.ReadLine();

            if(consumers.ContainsKey(id))
            {
                Consumer updatedConsumer = consumers[id];
                
                if(updatedConsumer.Activity == true)
                {
                    updatedConsumer.Activity = false;
                    updatedConsumer.Mode = Common.EMode.NONE;
                }
                else
                {
                    updatedConsumer.Activity = true;
                    updatedConsumer.Mode = Common.EMode.CONSUMING;
                }

                if(DBManager.S_Instance.UpdateConsumer(updatedConsumer))
                {
                    Console.WriteLine($"Consumer ID: {updatedConsumer.ConsumerID} updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Consumer ID: {updatedConsumer.ConsumerID} IS NOT updated.");
                }
            }
            else
            {
                Console.WriteLine("Consumer with that ID doesn't exist.");
            }
        }

        public void ChangeEVCCharging()
        {
            Console.WriteLine("List of EVCs => ");
            Dictionary<string, ElectricVehicleCharger> evcs = DBManager.S_Instance.GetAllElectricVehicleChargers();
            evcs.Values.ToList().ForEach(b => Console.WriteLine($"ID: {b.BatteryID}  MaxPower: {b.MaxPower}  MaxCapacity: {b.MaxCapacity}  CurrentCapacity: {b.CurrentCapacity}  Activity: {b.Activity}  Mode: {b.Mode}  OnCharger: {b.OnCharger}"));

            Console.WriteLine("EVC-Battery ID: ");
            string id = Console.ReadLine();

            if (evcs.ContainsKey(id))
            {
                ElectricVehicleCharger currentEVC = DBManager.S_Instance.GetSingleElectricVehicleCharger(id);

                Console.WriteLine("Do you want to:");
                Console.WriteLine("1) Change charger state");
                Console.WriteLine("2) Change activity state");
                Console.WriteLine();
                
                Console.WriteLine("Your answer: ");
                Int32.TryParse(Console.ReadLine(), out answer2);


                switch(answer2)
                {
                    case 1:
                        {
                            if(currentEVC.OnCharger == true)
                            {
                                currentEVC.OnCharger = false;
                                currentEVC.Activity = false;        // aktivnost punjenja (nasledjena karakteristika baterije)
                                currentEVC.Mode = Common.EMode.NONE;
                            }
                            else
                            {
                                currentEVC.OnCharger = true;
                            }

                            break;
                        }
                    case 2:
                        {
                            if(currentEVC.Activity == true)
                            {
                                currentEVC.Activity = false;
                                currentEVC.Mode = Common.EMode.NONE;
                            }
                            else
                            {
                                if(currentEVC.OnCharger == true)
                                {
                                    currentEVC.Activity = true;
                                    currentEVC.Mode = Common.EMode.CONSUMING;
                                }
                                else
                                {
                                    Console.WriteLine($"You can't activate EVC-battery with ID: {id} because it is not on charger.");
                                }
                            }

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Your answer is NOT VALID !");
                            break;
                        }
                }


                if(DBManager.S_Instance.UpdateElecticVehicleCharger(currentEVC))
                {
                    Console.WriteLine($"EVC ID: {currentEVC.BatteryID} updated successfully.");
                }
                else
                {
                    Console.WriteLine($"EVC ID: {currentEVC.BatteryID} IS NOT updated.");
                }
            }
            else
            {
                Console.WriteLine("EVC with that ID doesn't exist.");
            }
        }

        public void ShowReport()
        {
            // iscrtaj grafik sa 4 krive
            //
            //      proizvodnja panela
            //      energija iz baterija (+ / -)
            //      uvoz iz utility-a (+ / -)
            //      ukupna potrosnja
        }

        public void ShowFinancialState()
        {
            // prikazi trenutnu vrednost promenljive KASA (?)
        }

        public void DriveCar()
        {
            // ovo treba u posebnom tasku da se periodicno smanjuje 'CurrentCapacity'
            // treba promeniti polja 'OnCharger', 'Activity' i 'Mode'
        }
    }
}
