using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Model
{
    public class SolarPanel
    {
        [Key]
        public string SolarPanelID { get; set; }
        public double MaxPower { get; set; }
    }
}
