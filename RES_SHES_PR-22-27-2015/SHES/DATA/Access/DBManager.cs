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
