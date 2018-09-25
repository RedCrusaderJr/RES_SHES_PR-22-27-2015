using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalTimer
{
    public class UniversalTimer_Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UniversalTimer: Hello world!");

            UniversalClock_Server server = new UniversalClock_Server();
            server.Open();

            while (true)
            {
                Console.WriteLine($"Global Time: Hours format[{UniversalClock.S_Instance.TimeHours}]     " +
                                  $"Minutes format[{UniversalClock.S_Instance.TimeMinutes}]     " +
                                  $"Seconds format[{UniversalClock.S_Instance.TimeSeconds}]     " +
                                  $"Day format[{UniversalClock.S_Instance.TimeDay}]");

                Thread.Sleep(Constants.MILISECONDS_IN_SECOND);
            }
        }
    }
}