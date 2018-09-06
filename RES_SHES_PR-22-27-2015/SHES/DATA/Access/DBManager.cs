using SHES.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Access
{
    class DBManager
    {

        #region Instance
        private static DBManager s_instance;

        private DBManager() { }

        public static DBManager S_Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new DBManager();
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

        #region GetOperations
        public Battery GetBattery(String id)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                return dbContext.Batteries.FirstOrDefault(b => b.BatteryID.Equals(id));
            }
        }

        public Consumer GetConsumer(String id)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                return dbContext.Consumers.FirstOrDefault(c => c.ConsumerID.Equals(id));
            }
        }

        public SolarPanel GetSolarPanel(String id)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                return dbContext.SolarPanels.FirstOrDefault(s => s.SolarPanelID.Equals(id));
            }
        }

        public ElectricVehicleCharger GetElectricVehicleCharger(String id)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                return dbContext.ElectricVehicleChargers.FirstOrDefault(evc => evc.BatteryID.Equals(id));
            }
        }
        #endregion
    }
}
