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
        void StartTimer();
        [OperationContract]
        Int32 GetGlobalTimeInSeconds();
        [OperationContract]
        Int32 GetGlobalTimeInMinutes();
        [OperationContract]
        Double GetGlobalTimeInHours();
        [OperationContract]
        Int32 GetGlobalTimeDay();
        [OperationContract]
        Tuple<Int32, Double> GetGlobalTimeInDayAndHour();
    }

    [ServiceContract]
    public interface IWeatherForecast
    {
        [OperationContract]
        Int32 GetSunlightPercentage();
    }

    [ServiceContract]
    public interface IPowerPrice
    {
        [OperationContract]
        Double GetPowerPrice();

        [OperationContract]
        Tuple<Tuple<Int32, Double>, Double> GetPowerPriceWithDate();
    }
}
