using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IUniversalClock
    {
        Int32 TimeSeconds { get; }
        Int32 TimeMinutes { get; }
        Double TimeHours { get; }
        Int32 TimeDay { get; }
    }
}
