using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common.Model;

namespace Common
{
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

    [ServiceContract]
    public interface IUniversalClock
    {
        [OperationContract]
        Int32 GetTimeInMinutes();

        [OperationContract]
        Int32 GetDay();
    }

    [ServiceContract]
    public interface ISHES
    {
        [OperationContract]
        Dictionary<Double, IMeasurement> GetInfoForDate(String date);
    }
}
