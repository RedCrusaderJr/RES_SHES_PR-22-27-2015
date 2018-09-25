using Common;
using Common.Model;
using SHES.Data.Access;
using SHES.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SHES_Graphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private String _currentTimeProperty;
        private String _currentPrice;
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();
        

        public ObservableCollection<String> ListOfDays { get; set; }
        public String CurrentTimeProperty
        {
            get { return _currentTimeProperty; }
            set
            {
                _currentTimeProperty = value;
                OnPropertyChanged("CurrentTime");
            }
        }
        public String CurrentPriceProperty
        {
            get { return _currentPrice; }
            set
            {
                _currentPrice = value;
                OnPropertyChanged("CurrentPrice");
            }
        }
        public Int32 TotalMinutes { get; set; }
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            ListOfDays = new ObservableCollection<string>();

            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.RunWorkerAsync();

            BindPropertyToUIElement(CurrentTimeProperty, CurrentTime, TextBlock.TextProperty, "CurrentTime");
            BindPropertyToUIElement(CurrentPriceProperty, CurrentPrice, TextBlock.TextProperty, "CurrentPrice");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ISHES proxy = ConnectToSHES();
            //OVDE PUCA!!!!!!!!!!!!!!!!!
            Dictionary<Double, IMeasurement> measurementsForDay = proxy.GetInfoForDate(GraphDate.SelectedValue.ToString());

            Dictionary<String, Double> solarPanelProduction = measurementsForDay.ToDictionary(m => TotalHoursToString(m.Key), m => m.Value.SolarPanelProduction);
            ((LineSeries)chart.Series[0]).ItemsSource = solarPanelProduction;

            Dictionary<String, Double> batteryConsumptionProduction = measurementsForDay.ToDictionary(m => TotalHoursToString(m.Key), m => m.Value.BatteryBalance);
            ((LineSeries)chart.Series[1]).ItemsSource = batteryConsumptionProduction;

            Dictionary<String, Double> powerFromUtility = measurementsForDay.ToDictionary(m => TotalHoursToString(m.Key), m => m.Value.PowerFromUtility);
            ((LineSeries)chart.Series[2]).ItemsSource = powerFromUtility;

            Dictionary<String, Double> totalConsumption = measurementsForDay.ToDictionary(m => TotalHoursToString(m.Key), m => m.Value.TotalConsumption);
            ((LineSeries)chart.Series[3]).ItemsSource = totalConsumption;

            Dictionary<String, Double> powerPrice = measurementsForDay.ToDictionary(m => TotalHoursToString(m.Key), m => m.Value.PowerPrice);
            ((LineSeries)chart.Series[4]).ItemsSource = powerPrice;
        }

        private String TotalHoursToString(Double totalHours)
        {
            TotalMinutes = (Int32) (totalHours * Constants.MINUTES_IN_HOUR);
            TimeSpan ts = TimeSpan.FromMinutes(TotalMinutes);
            return String.Format($"{ts.Hours} : {ts.Minutes}");
        }

        private ISHES ConnectToSHES()
        { 
            NetTcpBinding binding = new NetTcpBinding()
            {
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                SendTimeout = new TimeSpan(0, 10, 0),
            };
            return new ChannelFactory<ISHES>(binding, new EndpointAddress("net.tcp://localhost:6005/SHES")).CreateChannel();
        }
        private IPowerPrice ConnectToUtility()
        {
            NetTcpBinding binding = new NetTcpBinding()
            {
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                SendTimeout = new TimeSpan(0, 10, 0),
            };
            return new ChannelFactory<IPowerPrice>(binding, new EndpointAddress("net.tcp://localhost:6002/PowerPrice")).CreateChannel();
        }
        private IUniversalClock ConnectToUniversalClock()
        {
            NetTcpBinding binding = new NetTcpBinding()
            {
                CloseTimeout = new TimeSpan(0, 10, 0),
                OpenTimeout = new TimeSpan(0, 10, 0),
                ReceiveTimeout = new TimeSpan(0, 10, 0),
                SendTimeout = new TimeSpan(0, 10, 0),
            };
            return new ChannelFactory<IUniversalClock>(binding, new EndpointAddress("net.tcp://localhost:6004/UniversalClock")).CreateChannel();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                IUniversalClock universalClockProxy = ConnectToUniversalClock();
                TotalMinutes = universalClockProxy.GetTimeInMinutes();
                TimeSpan ts = TimeSpan.FromMinutes(TotalMinutes);

                IPowerPrice utilityProxy = ConnectToUtility();

                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    CurrentTimeProperty = String.Format($"{ts.Hours} : {ts.Minutes}");
                    CurrentPriceProperty = String.Format($"Current price: {utilityProxy.GetPowerPrice()} [$/kWh]");

                    Int32 day = universalClockProxy.GetDay();
                    if (day - 1 != 0)
                    {
                        String newDayString = $"{day - 1}. dan od startovanja aplikacije";

                        if (!ListOfDays.Contains(newDayString))
                        {
                            ListOfDays.Add(newDayString);
                        }
                    }    
                }));

                Thread.Sleep(Constants.MILISECONDS_IN_SECOND);
            }
        }

        private void BindPropertyToUIElement(Object source, DependencyObject target, DependencyProperty dp, String nameOfProperty)
        {
            Binding binding = new Binding
            {
                Source = source,
                Path = new PropertyPath(nameOfProperty),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(target, dp, binding);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string parameter)
        {

            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(parameter));
            }

        } 
        #endregion
    }
}
