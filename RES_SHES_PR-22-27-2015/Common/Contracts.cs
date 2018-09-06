using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IUniversalTimer
    {
        [OperationContract]
        Int32 GetGlobalTimeInSeconds();
        [OperationContract]
        Int32 GetGlobalTimeInMinutes();
        [OperationContract]
        Double GetGlobalTimeInHours();
    }


    [ServiceContract]
    public interface IWeatherForecast
    {
        [OperationContract]
        Int32 GetSunlightPercentage();
    }
}
