using Common;
using SHES.Data.Model;
using SHES.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace SHES
{
    class SHES_Provider : ISHES
    {
        public Dictionary<Double, IMeasurement> GetInfoForDate(string date)
        {
            Dictionary<Double, IMeasurement> measurements = DBManager.S_Instance.GetAllMeasurementsBySpecificDay(int.Parse(date.Split('.')[0]));
            return measurements;
        }
    }
}
