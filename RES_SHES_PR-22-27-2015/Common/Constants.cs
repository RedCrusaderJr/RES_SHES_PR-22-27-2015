using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Constants
    {
        public const int ACCELERATION = 10;

        public const int MILISECONDS_IN_SECOND = 1000 / ACCELERATION;
        public const int MILISECONDS_IN_MINUTE = MILISECONDS_IN_SECOND * SECONDS_IN_MINUTE;

        public const int SECONDS_IN_MINUTE = 60 / ACCELERATION;
        public const int MINUTES_IN_HOUR = 60 / ACCELERATION;
        public const int HOURS_IN_DAY = 24;
        public const int SECONDS_IN_DAY = SECONDS_IN_MINUTE * MINUTES_IN_HOUR * HOURS_IN_DAY;


        public const int WAITING_TIME = 1000;
    }
}
