using Common;
using SHES.Data.Access;
using SHES.Data.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{
    public class SHES_Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SHES: Hello world!");

            AppStarter();
            Thread.Sleep(1000);

            // set |DataDirectory| in App.config
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin")) + "DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            DBManager dBManager = DBManager.S_Instance;

            if(dBManager.AddBattery(new Battery() { BatteryID = "123", Capacity = 5, MaxPower = 55 }))
            {
                Console.WriteLine("Battery added successfully!");
            }
                        
            Menu myMenu = new Menu();
            myMenu.Display();
        }

        static IUniversalTimer Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();
            Thread.Sleep(5000);
            ChannelFactory<IUniversalTimer> factory = new ChannelFactory<IUniversalTimer>(binding, new EndpointAddress("net.tcp://localhost:6000/UniversalTimer"));

            return factory.CreateChannel();
        }

        static void AppStarter()
        {
            String absolutePath = Path.GetFullPath(@"..\..\..\");

            //UniversalTimer
            Process.Start($@"{absolutePath}UniversalTimer\bin\Debug\UniversalTimer");

            //WeatherSimulator
            Process.Start($@"{absolutePath}WeatherSimulator\bin\Debug\WeatherSimulator");

            //Utility
            Process.Start($@"{absolutePath}Utility\bin\Debug\Utility");
        }
    }
}
