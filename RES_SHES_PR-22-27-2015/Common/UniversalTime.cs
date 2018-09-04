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
        private static UniversalTime _instance;

        private static object _timeLock = new object();

        // datetime promenljiva

        private UniversalTime()
        {
            
        }

        public static UniversalTime S_UniversalTime
        {
            get
            {
                if(_instance == null)
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
    }
}
