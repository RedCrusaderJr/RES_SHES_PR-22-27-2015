using SHES.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    class Menu
    {
        private Int32 answer1;
        private Int32 answer2;

        public void Display()
        {
            do
            {
                Console.WriteLine("   *** MENU ***   ");
                Console.WriteLine();

                Console.WriteLine("1. Add some element");
                Console.WriteLine("2. Remove some element");
                Console.WriteLine("3. Change consumer's activity");
                Console.WriteLine("4. Change EVC's charging");
                Console.WriteLine("5. Show report (graphic)");
                Console.WriteLine("6. Show financial state");
                Console.WriteLine("7. EXIT");

                Console.WriteLine();
                Console.WriteLine("Your answer: ");
                Int32.TryParse(Console.ReadLine(), out answer1);

                Console.WriteLine();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine();
                

                switch(answer1)
                {
                    case 1:
                        {
                            AddSomeElement();
                            break;
                        }

                    case 2:
                        {
                            RemoveSomeElement();
                            break;
                        }

                    case 3:
                        {
                            ChangeConsumerActivity();
                            break;
                        }
                    case 4:
                        {
                            ChangeEVCCharging();
                            break;
                        }
                    case 5:
                        {
                            ShowReport();
                            break;
                        }
                    case 6:
                        {
                            ShowFinancialState();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Goodbye !");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Your answer is NOT VALID !");
                            break;
                        }
                }
            }
            while (answer1 != 4);
        }


        #region Adding

        public void AddSomeElement()
        {
            Console.WriteLine("1) Add Solar panel");
            Console.WriteLine("2) Add Battery");
            Console.WriteLine("3) Add Electric vehicle charger");
            Console.WriteLine("4) Add Consumer");
            Console.WriteLine("5) BACK");

            Console.WriteLine();
            Console.WriteLine("Your answer: ");
            Int32.TryParse(Console.ReadLine(), out answer2);

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();


            switch (answer2)
            {
                case 1:
                    {
                        AddSolarPanel();
                        break;
                    }
                case 2:
                    {
                        AddBattery();
                        break;
                    }
                case 3:
                    {
                        AddEVC();
                        break;
                    }
                case 4:
                    {
                        AddConsumer();
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Your answer is NOT VALID !");
                        break;
                    }
            }
        }



        public void AddSolarPanel()
        {
            SolarPanel sp = new SolarPanel();

            Console.WriteLine("Solar panel ID: ");
            // provera jedinstvenosti
            sp.SolarPanelID = Console.ReadLine();

            Console.WriteLine("Solar panel MaxPower: ");
            sp.MaxPower = Double.Parse(Console.ReadLine());


            // dodaj sp u bazu
        }

        public void AddBattery()
        {
            Battery b = new Battery();

            Console.WriteLine("Battery ID: ");
            // provera jedinstvenosti
            b.BatteryID = Console.ReadLine();

            Console.WriteLine("Battery MaxPower: ");
            b.MaxPower = Double.Parse(Console.ReadLine());

            Console.WriteLine("Batery Capacity: ");
            b.Capacity = Double.Parse(Console.ReadLine());


            // dodaj b u bazu
        }

        public void AddEVC()
        {
            ElectricVehicleCharger evc = new ElectricVehicleCharger();

            Console.WriteLine("EVC-Battery ID: ");
            // provera jedinstvenosti
            evc.BatteryID = Console.ReadLine();

            Console.WriteLine("EVC-Battery MaxPower: ");
            evc.MaxPower = Double.Parse(Console.ReadLine());

            Console.WriteLine("EVC-Batery Capacity: ");
            evc.Capacity = Double.Parse(Console.ReadLine());

            evc.Activity = false;


            // dodaj evc u bazu
        }

        public void AddConsumer()
        {
            Consumer c = new Consumer();

            Console.WriteLine("Consumer ID: ");
            // provera jedinstvenosti
            c.ConsumerID = Console.ReadLine();

            Console.WriteLine("Consumption: ");
            c.Consumption = Double.Parse(Console.ReadLine());

            c.Activity = false;


            // dodaj c u bazu
        }

        #endregion


        #region Removing

        public void RemoveSomeElement()
        {
            Console.WriteLine("1) Remove Solar panel");
            Console.WriteLine("2) Remove Battery");
            Console.WriteLine("3) Remove Electric vehicle charger");
            Console.WriteLine("4) Remove Consumer");
            Console.WriteLine("5) BACK");

            Console.WriteLine();
            Console.WriteLine("Your answer: ");
            Int32.TryParse(Console.ReadLine(), out answer2);

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();


            switch (answer2)
            {
                case 1:
                    {
                        RemoveSolarPanel();
                        break;
                    }
                case 2:
                    {
                        RemoveBattery();
                        break;
                    }
                case 3:
                    {
                        RemoveEVC();
                        break;
                    }
                case 4:
                    {
                        RemoveConsumer();
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Your answer is NOT VALID !");
                        break;
                    }
            }
        }


        public void RemoveSolarPanel()
        {
            // ispis svih ?

            Console.WriteLine("Solar panel ID: ");

            // proveri postojanje
            // PRISTUP BAZI
            // ukloni
        }

        public void RemoveBattery()
        {
            // ispis svih ?

            Console.WriteLine("Battery ID: ");

            // proveri postojanje
            // PRISTUP BAZI
            // ukloni
        }

        public void RemoveEVC()
        {
            // ispis svih ?

            Console.WriteLine("EVC-Battery ID: ");

            // proveri postojanje
            // PRISTUP BAZI
            // ukloni
        }

        public void RemoveConsumer()
        {
            // ispis svih ?

            Console.WriteLine("Consumer ID: ");

            // proveri postojanje
            // PRISTUP BAZI
            // ukloni
        }

        #endregion


        public void ChangeConsumerActivity()
        {

            // izlistaj sve Consumer - e (PRISTUP BAZI)
            // prihvati ID onog cija se aktivnost menja
            // izmeni njegovu aktivnost

        }

        public void ChangeEVCCharging()
        {
            // izlistaj sve EVC - ove
            // prihati ID, komandu za punjac i aktivnost
        }

        public void ShowReport()
        {
            // iscrtaj grafik sa 4 krive
            //
            //      proizvodnja panela
            //      energija iz baterija (+ / -)
            //      uvoz iz utility-a (+ / -)
            //      ukupna potrosnja
        }

        public void ShowFinancialState()
        {
            // prikazi trenutnu vrednost promenljive KASA (?)
        }
    }
}
