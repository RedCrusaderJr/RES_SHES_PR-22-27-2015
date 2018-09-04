using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public class UniversalTime
    {
        #region Instance
        private static UniversalTime _instance;
        private static readonly object _timeLock = new object();

        public static UniversalTime S_UniversalTime
        {
            get
            {
                if (_instance == null)
                {
                    lock (_timeLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UniversalTime();
                        }
                    }
                }

                return _instance;
            }

            private set
            {
                _instance = value;
            }
        }
        #endregion

        private int _time;

        public int Time
        {
            get
            {
                return (_time % (24 * 60 * 60)) + 1;
            }

            private set
            {
                _time = value;
            }
        }

        public int GetTimeInMinutes()
        {
            return (Time / 60) + 1;
        }

        public double GetTimeInHours()
        {
            return (Time / (60 * 60)) + 1;
        }

        private UniversalTime()
        {
            Time = 0;
            Task timeTracker = new Task( () => {
                while (true)
                {
                    Time++;
                    Thread.Sleep(1);
                }
            });

            timeTracker.Start();
        } 
    }
}
