using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalTimer
{
    public class UniversalClock_Provider : IUniversalClockService
    {
        public int GetDay()
        {
            return UniversalClock.S_Instance.TimeDay;
        }

        public double GetTimeInHours()
        {
            return UniversalClock.S_Instance.TimeHours;
        }

        public int GetTimeInMinutes()
        {
            return UniversalClock.S_Instance.TimeMinutes;
        }

        public int GetTimeInSeconds()
        {
            return UniversalClock.S_Instance.TimeSeconds;
        }
    }
}
