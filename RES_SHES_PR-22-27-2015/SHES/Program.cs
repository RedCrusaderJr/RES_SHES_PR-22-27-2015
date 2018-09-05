using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SHES: Hello world!");

            UniversalTime globalTime = UniversalTime.S_UniversalTime;

            Console.WriteLine("Timer started");

            while(true)
            {
                Console.WriteLine($"Global Time: Hours format[{globalTime.GetTimeInHours()}]     Minutes format[{globalTime.GetTimeInMinutes()}]     Seconds format[{globalTime.Time}]");
                Thread.Sleep(2000);
            }
        }
    }
}
