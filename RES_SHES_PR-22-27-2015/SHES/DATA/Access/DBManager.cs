﻿using Common.IModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SHES.Data.Model;
using System.Data.Entity;

namespace SHES.Data.Access
{
    public class DBManager
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

        public bool AddMeasurement(Measurement measurement)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.Measurements.Any(m => m.MesurementID.Equals(measurement.MesurementID));
                if (found)
                {
                    return false;
                }

                dbContext.Measurements.Add(measurement);
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

                    foundBattery.MaxPower = battery.MaxPower;
                    foundBattery.MaxCapacity = battery.MaxCapacity;
                    foundBattery.CurrentCapacity = battery.CurrentCapacity;
                    foundBattery.Mode = battery.Mode;

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

                    foundConsumer.Consumption = consumer.Consumption;
                    foundConsumer.IsConsuming = consumer.IsConsuming;

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

                    foundSolarPanel.MaxPower = solarPanel.MaxPower;

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

                    foundEVC.MaxPower = electricVehicleCharger.MaxPower;
                    foundEVC.MaxCapacity = electricVehicleCharger.MaxCapacity;
                    foundEVC.CurrentCapacity = electricVehicleCharger.CurrentCapacity;
                    foundEVC.Mode = electricVehicleCharger.Mode;
                    foundEVC.OnCharger = electricVehicleCharger.OnCharger;

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

        public Dictionary<Double, IMeasurement> GetAllMeasurementsBySpecificDay(Int32 day)
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                Dictionary<Double, IMeasurement> measurements = UniqueDictionaryKey(dbContext.Measurements, day);
                if (measurements == null)
                {
                    measurements = new Dictionary<Double, IMeasurement>();
                }

                return measurements;
            }
        }

        public Dictionary<Int32, Dictionary<Double, IMeasurement>> GetAllMeasurements()
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                Dictionary<Int32, Dictionary<Double, IMeasurement>> measurements = dbContext.Measurements.ToDictionary(m => m.Day, m => GetAllMeasurementsBySpecificDay(m.Day));
                if (measurements == null)
                {
                    measurements = new Dictionary<Int32, Dictionary<Double, IMeasurement>>();
                }

                return measurements;
            }
        }

        private Dictionary<Double, IMeasurement> UniqueDictionaryKey(DbSet<Measurement> measurements, Int32 day)
        {
            Dictionary<Double, IMeasurement> measurementDictionary = new Dictionary<Double, IMeasurement>();
            var measurementsForDay = measurements.Where(m => m.Day == day);

            foreach (var foo in measurementsForDay)
            {
                if (!measurementDictionary.ContainsKey(foo.HourOfTheDay))
                {
                    measurementDictionary.Add(foo.HourOfTheDay, foo);
                }
            }

            return measurementDictionary;
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

        public bool RemoveAllMeasurements()
        {
            using (SHES_DBContext dbContext = new SHES_DBContext())
            {
                bool found = dbContext.Measurements.Any();
                if (found)
                {
                    dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Measurements]");

                    return true;
                }

                return false;
            }
        }
        #endregion
    }
}
