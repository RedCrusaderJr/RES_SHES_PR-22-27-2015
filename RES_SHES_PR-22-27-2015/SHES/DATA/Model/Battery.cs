using Common;
using Common.IModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    public class Battery : IBattery
    {
        [Key]
        public string BatteryID { get; set; }
        public double MaxPower { get; set; }
        public double MaxCapacity { get; set; }
        public double CurrentCapacity { get; set; }
        public EMode Mode { get; set; }

        public Battery() { }

        public Battery(string id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("ID cannot be null!");
            }

            if(id == "")
            {
                throw new ArgumentException("ID cannot be empty!");
            }

            BatteryID = id;
        }

        public Battery(Battery b)
        {
            if(b == null)
            {
                throw new ArgumentNullException("Battery cannot be null!");
            }

            BatteryID = b.BatteryID;
            MaxPower = b.MaxPower;
            MaxCapacity = b.MaxCapacity;
            CurrentCapacity = b.CurrentCapacity;
            Mode = b.Mode;
        }

        public void Consuming()
        {
            if(Math.Round((CurrentCapacity * 60 + 1) / (double)60, 2) <= MaxCapacity)
            {
                CurrentCapacity = Math.Round((CurrentCapacity * 60 + 1) / (double)60, 2);
                Mode = EMode.CONSUMING;
            }
            else
            {
                Mode = EMode.NONE;
            }
        }

        public void Generating()
        {
            if(Math.Round((CurrentCapacity * 60 - 1) / (double)60, 2) >= 0)
            {
                CurrentCapacity = Math.Round((CurrentCapacity * 60 - 1) / (double)60, 2);
                Mode = EMode.GENERATING;
            }
            else
            {
                Mode = EMode.NONE;
            }
        }
    }
}
