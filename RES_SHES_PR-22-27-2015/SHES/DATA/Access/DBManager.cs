using SHES.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES.Data.Access
{
    class DBManager
    {

        #region Instance
        private static DBManager s_instance;
        private static readonly object syncLock = new object();
        private DBManager() { }

        public static DBManager S_Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock(syncLock)
                    {
                        if (s_instance == null)
                        {
                            s_instance = new DBManager();
                        }
                    }
                }

                return s_instance;
            }
        }
        #endregion

        #region AddOperations
        public bool AddBattery(Battery battery)
        {
            using(SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.Batteries.Any(b => b.BatteryID.Equals(battery.BatteryID));
                if(found)
                {
                    return false;
                }

                dbContext.Batteries.Add(battery);
                dbContext.SaveChanges();

                return true;
            }
        } 

        public bool AddConsumer(Consumer consumer)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.Consumers.Any(c => c.ConsumerID.Equals(consumer.ConsumerID));
                if (found)
                {
                    return false;
                }

                dbContext.Consumers.Add(consumer);
                dbContext.SaveChanges();

                return true;
            }
        }

        public bool AddSolarPanel(SolarPanel solarPanel)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.SolarPanels.Any(s => s.SolarPanelID.Equals(solarPanel.SolarPanelID));
                if (found)
                {
                    return false;
                }

                dbContext.SolarPanels.Add(solarPanel);
                dbContext.SaveChanges();

                return true;
            }
        }

        public bool AddElecticVehicleCharger(ElectricVehicleCharger electricVehicleCharger)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.ElectricVehicleChargers.Any(evc => evc.BatteryID.Equals(electricVehicleCharger.BatteryID));
                if (found)
                {
                    return false;
                }

                dbContext.ElectricVehicleChargers.Add(electricVehicleCharger);
                dbContext.SaveChanges();

                return true;
            }
        }
        #endregion

        #region UpdateOperations
        public bool UpdateBattery(Battery battery)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.Batteries.Any(b => b.BatteryID.Equals(battery.BatteryID));
                if (found)
                {
                    Battery foundBattery = dbContext.Batteries.SingleOrDefault(b => b.BatteryID.Equals(battery.BatteryID));
                    dbContext.Batteries.Attach(foundBattery);
                    foundBattery = new Battery(battery);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool UpdateConsumer(Consumer consumer)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.Consumers.Any(c => c.ConsumerID.Equals(consumer.ConsumerID));
                if (found)
                {
                    Consumer foundConsumer = dbContext.Consumers.SingleOrDefault(c => c.ConsumerID.Equals(consumer.ConsumerID));
                    dbContext.Consumers.Attach(foundConsumer);
                    foundConsumer = new Consumer(consumer);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool UpdateSolarPanel(SolarPanel solarPanel)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.SolarPanels.Any(s => s.SolarPanelID.Equals(solarPanel.SolarPanelID));
                if (found)
                {
                    SolarPanel foundSolarPanel = dbContext.SolarPanels.SingleOrDefault(s => s.SolarPanelID.Equals(solarPanel.SolarPanelID));
                    dbContext.SolarPanels.Attach(foundSolarPanel);
                    foundSolarPanel = new SolarPanel(solarPanel);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool UpdateElecticVehicleCharger(ElectricVehicleCharger electricVehicleCharger)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.ElectricVehicleChargers.Any(evc => evc.BatteryID.Equals(electricVehicleCharger.BatteryID));
                if (found)
                {
                    ElectricVehicleCharger foundEVC = dbContext.ElectricVehicleChargers.SingleOrDefault(evc => evc.BatteryID.Equals(electricVehicleCharger.BatteryID));
                    dbContext.ElectricVehicleChargers.Attach(foundEVC);
                    foundEVC = new ElectricVehicleCharger(foundEVC);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }
        #endregion

        #region GetOperations
        public Battery GetSingleBattery(String id)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                return dbContext.Batteries.FirstOrDefault(b => b.BatteryID.Equals(id));
            }
        }

        public Dictionary<string, Battery> GetAllBatteries()
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                Dictionary<string, Battery> batteries = dbContext.Batteries.ToDictionary(b => b.BatteryID, b => b);
                if (batteries == null)
                {
                    batteries = new Dictionary<string, Battery>();
                }

                return batteries;
            }
        }

        public Consumer GetSingleConsumer(String id)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                return dbContext.Consumers.FirstOrDefault(c => c.ConsumerID.Equals(id));
            }
        }

        public Dictionary<string, Consumer> GetAllConsumers()
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                Dictionary<string, Consumer> consumers = dbContext.Consumers.ToDictionary(c => c.ConsumerID, c => c);
                if (consumers == null)
                {
                    consumers = new Dictionary<string, Consumer>();
                }

                return consumers;
            }
        }

        public SolarPanel GetSingleSolarPanel(String id)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                return dbContext.SolarPanels.FirstOrDefault(s => s.SolarPanelID.Equals(id));
            }
        }

        public Dictionary<string, SolarPanel> GetAllSolarPanels()
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                Dictionary<string, SolarPanel> solarPanels = dbContext.SolarPanels.ToDictionary(s => s.SolarPanelID, s => s);
                if (solarPanels == null)
                {
                    solarPanels = new Dictionary<string, SolarPanel>();
                }

                return solarPanels;
            }
        }

        public ElectricVehicleCharger GetSingleElectricVehicleCharger(String id)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                return dbContext.ElectricVehicleChargers.FirstOrDefault(evc => evc.BatteryID.Equals(id));
            }
        }

        public Dictionary<string, ElectricVehicleCharger> GetAllElectricVehicleChargers()
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                Dictionary<string, ElectricVehicleCharger> electricVehicleChargers = dbContext.ElectricVehicleChargers.ToDictionary(evc => evc.BatteryID, evc => evc);
                if (electricVehicleChargers == null)
                {
                    electricVehicleChargers = new Dictionary<string, ElectricVehicleCharger>();
                }

                return electricVehicleChargers;
            }
        }
        #endregion

        #region RemoveOperations
        public bool RemoveBattery(Battery battery)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.Batteries.Any(b => b.BatteryID.Equals(battery.BatteryID));
                if (found)
                {
                    dbContext.Batteries.Attach(battery);
                    dbContext.Batteries.Remove(battery);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool RemoveConsumer(Consumer consumer)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.Consumers.Any(c => c.ConsumerID.Equals(consumer.ConsumerID));
                if (found)
                {
                    dbContext.Consumers.Attach(consumer);
                    dbContext.Consumers.Remove(consumer);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool RemoveSolarPanel(SolarPanel solarPanel)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.SolarPanels.Any(s => s.SolarPanelID.Equals(s.SolarPanelID));
                if (found)
                {
                    dbContext.SolarPanels.Attach(solarPanel);
                    dbContext.SolarPanels.Remove(solarPanel);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool RemoveElectricVehicleCharger(ElectricVehicleCharger evc)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.ElectricVehicleChargers.Any(e => e.BatteryID.Equals(evc.BatteryID));
                if (found)
                {
                    dbContext.ElectricVehicleChargers.Attach(evc);
                    dbContext.ElectricVehicleChargers.Remove(evc);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }
        #endregion
    }
}
