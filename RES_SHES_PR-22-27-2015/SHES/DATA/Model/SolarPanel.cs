using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    public class SolarPanel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SolarPanelID { get; set; }
        public double MaxPower { get; set; }
        public EMode Mode { get; set; } = EMode.GENERATING;


        public double CalculatePower()
        {
            IWeatherForecast proxy = Connect();
            return (MaxPower * proxy.GetSunlightPercentage() / 100);
        }

        private IWeatherForecast Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();

            return new ChannelFactory<IWeatherForecast>(binding, new EndpointAddress("net.tcp://localhost:6001/WeatherForecast")).CreateChannel();
        }
    }
}
