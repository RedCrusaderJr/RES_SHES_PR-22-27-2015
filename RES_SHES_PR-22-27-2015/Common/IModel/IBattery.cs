using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IModel
{
    public interface IBattery
    {
        string BatteryID { get; set; }
        double MaxPower { get; set; }
        double MaxCapacity { get; set; }
        double CurrentCapacity { get; set; }
        EMode Mode { get; set; }

        void Consuming();
        void Generating();
    }
}
