using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    class Helper
    {
        public static double HoursToMinutes(double hours)
        {
            return hours * 60;
        }

        public static double MinutesToHours(double minutes)
        {
            return minutes / 60;
        }
    }
}
