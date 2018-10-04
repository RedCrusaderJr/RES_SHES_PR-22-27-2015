using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IWeatherForecast
    {
        [OperationContract]
        Int32 GetSunlightPercentage(Double hourOfTheDay);
    }

    [ServiceContract]
    public interface IPowerPrice
    {
        [OperationContract]
        Double GetPowerPrice(Double hourOfTheDay);

        [OperationContract]
        Tuple<Tuple<Int32, Double>, Double> GetPowerPriceWithDate(Double hourOfTheDay, Int32 Day);
    }

    [ServiceContract]
    public interface IUniversalClockService
    {
        [OperationContract]
        Int32 GetTimeInSeconds();

        [OperationContract]
        Int32 GetTimeInMinutes();

        [OperationContract]
        Double GetTimeInHours();

        [OperationContract]
        Int32 GetDay();
    }

    [ServiceContract]
    public interface ISHES
    {
        [OperationContract]
        List<Dictionary<String, Double>> GetInfoForDate(String date);
    }
}
