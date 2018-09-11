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
        private static Int32 s_day;

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

        /*
        public UniversalTimer_Provider()
        {
            Task task = new Task(() => {
                while(true)
                {
                    if(++S_Time % (24 * 60 * 60) == 0)
                    {
                        s_day++;
                    }

                    Thread.Sleep(Constants.SECOND);
                }
            });

            task.Start();
        }
        */

        //Drugi poziv?
        public void StartTimer()
        {
            S_Time = 0;
            s_day = 1;

            Task.Run(() => {
                while (true)
                {
                    if (++S_Time % (24 * 60 * 60) == 0)
                    {
                        s_day++;
                    }

                    Thread.Sleep(Constants.SECOND);
                }
            });
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

        public int GetGlobalTimeDay()
        {
            return s_day;
        }

        public Tuple<int, double> GetGlobalTimeInDayAndHour()
        {
            return new Tuple<int, double>(GetGlobalTimeDay(), GetGlobalTimeInHours());
        }
    }
}
