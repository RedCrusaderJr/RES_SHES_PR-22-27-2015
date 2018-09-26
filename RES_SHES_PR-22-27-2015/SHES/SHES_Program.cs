using Common;
using SHES.Data.Access;
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
            Thread.Sleep(Constants.WAITING_TIME);

            // set |DataDirectory| in App.config
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin")) + "DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            /*
            TestData();
            */
            DBManager.S_Instance.RemoveAllMeasurements();

            SHES_Server server = new SHES_Server();
            server.Open();

            Thread.Sleep(Constants.WAITING_TIME);
            StartAllTasks();

            Menu myMenu = new Menu();
            myMenu.Display();

            
        }

        static void AppStarter()
        {
            Console.WriteLine("Choose method for WeatherSimulator: ");
            Console.WriteLine("1) Auto");
            Console.WriteLine("2) Manual");
            Int32.TryParse(Console.ReadLine(), out int answer);

            String absolutePath = Path.GetFullPath(@"..\..\..\");
            
            //UniversalTimer
            Process.Start($@"{absolutePath}UniversalTimer\bin\Debug\UniversalTimer");

            //WeatherSimulator
            Process.Start($@"{absolutePath}WeatherSimulator\bin\Debug\WeatherSimulator", answer.ToString());

            //Utility
            Process.Start($@"{absolutePath}Utility\bin\Debug\Utility");

            //WPF
            Process.Start($@"{absolutePath}SHES_Graphics\bin\Debug\SHES_Graphics");
        }


        private static void StartAllTasks()
        {
            Task.Run(() => SHES_Tasks.BatteryBehavior());
            Task.Run(() => SHES_Tasks.CollectingMeasurements());
        }


        /*
        static void TestData()
        {
            DBManager dBManager = DBManager.S_Instance;

            if (dBManager.AddBattery(new Battery() { BatteryID = "123", MaxCapacity = 5, MaxPower = 55, CurrentCapacity = 0, Mode = EMode.NONE }))
            {
                Console.WriteLine("Battery added successfully!");
            }


            Consumer consumer = new Consumer("ID007") { Mode = EMode.NONE, Consumption = 12 };
            if (dBManager.AddConsumer(consumer))
            {
                Console.WriteLine("Consumer added successfully!");
            }
            else
            {
                Consumer con = dBManager.GetSingleConsumer(consumer.ConsumerID);
                consumer = new Consumer(con);
            }
        }
        */
    }
}
