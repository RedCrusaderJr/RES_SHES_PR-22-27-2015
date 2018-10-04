using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalTimer
{
    public class UniversalClock : IUniversalClock
    {
        #region Instance
        private static UniversalClock s_instance;
        private static readonly object syncLock = new object();
        public static UniversalClock S_Instance
        {
            get
            {
                if(s_instance == null)
                {
                    lock(syncLock)
                    {
                        if (s_instance == null)
                        {
                            s_instance = new UniversalClock();
                        }
                    }
                }

                return s_instance;
            }
        }
        #endregion

        private Int32 _timeSeconds;

        public Int32 TimeSeconds
        {
            get
            {
                return _timeSeconds % (Constants.SECONDS_IN_DAY);
            }
        }
        public Int32 TimeMinutes
        {
            get
            {
                return (TimeSeconds / Constants.SECONDS_IN_MINUTE);
            }
        }
        public Double TimeHours
        {
            get
            {
                return Math.Round(TimeSeconds / (double)(Constants.MINUTES_IN_HOUR * Constants.SECONDS_IN_MINUTE), 2);
            }
        }
        public Int32 TimeDay { get; private set; }

        private UniversalClock()
        {
            _timeSeconds = 0;
            TimeDay = 1;

            Task.Run(() =>
            {
                while (true)
                {
                    if (++_timeSeconds % (Constants.SECONDS_IN_DAY) == 0)
                    {
                        TimeDay++;
                    }

                    Thread.Sleep(Constants.MILISECONDS_IN_SECOND);
                }
            });
        }
    }
}
