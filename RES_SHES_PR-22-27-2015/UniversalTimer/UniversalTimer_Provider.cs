using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalTimer
{
    public class UniversalTimer_Provider : IUniversalTimer
    {
        private static Int32 s_time;

        public static Int32  S_Time
        {
            get
            {
                return s_time % (24 * 60 * 60);
            }

            private set
            {
                s_time = value;
            }
        }

        public UniversalTimer_Provider()
        {
            Task task = new Task(() => {
                while(true)
                {
                    S_Time++;
                    Thread.Sleep(10);
                }
            });

            task.Start();
        }

        public double GetGlobalTimeInHours()
        {
            return Math.Round(S_Time / (double)(60 * 60), 2);
        }

        public int GetGlobalTimeInMinutes()
        {
            return (S_Time / 60);
        }

        public int GetGlobalTimeInSeconds()
        {
            return S_Time;
        }
    }
}
