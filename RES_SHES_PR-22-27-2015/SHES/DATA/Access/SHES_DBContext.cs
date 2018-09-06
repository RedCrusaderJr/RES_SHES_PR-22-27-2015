using SHES.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Access
{
    class SHES_DBContext : DbContext
    {
        public SHES_DBContext() : base("SHES_DBConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SHES_DBContext, Configuration>());
        }

        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<SolarPanel> SolarPanels { get; set; }
        public DbSet<ElectricVehicleCharger> ElectricVehicleChargers { get; set; }
    }
}
