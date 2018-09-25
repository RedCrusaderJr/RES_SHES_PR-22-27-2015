using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalTimer
{
    public class UniversalClock_Provider : IUniversalClock
    {
        public int GetDay()
        {
            return UniversalClock.S_Instance.TimeDay;
        }

        public int GetTimeInMinutes()
        {
            return UniversalClock.S_Instance.TimeMinutes;
        }
    }
}
