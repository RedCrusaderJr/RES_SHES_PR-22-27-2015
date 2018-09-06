﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    public enum BatteryMode { CHARGING, NOT_CHARGING, NONE };

    public class Battery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BatteryID { get; set; }
        public double MaxPower { get; set; }
        public double Capacity { get; set; }
        public BatteryMode Mode { get; set; }
    }
}
