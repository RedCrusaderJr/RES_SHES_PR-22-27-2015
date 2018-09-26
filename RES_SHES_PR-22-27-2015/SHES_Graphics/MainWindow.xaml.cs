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
                CurrentTime.Text = _currentTimeProperty;
            }
        }
        public String CurrentPriceProperty
        {
            get { return _currentPrice; }
            set
            {
                _currentPrice = value;
                CurrentPrice.Text = _currentPrice;
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

            //BindPropertyToUIElement(CurrentTimeProperty, CurrentTime, TextBlock.TextProperty, "CurrentTime");
            //BindPropertyToUIElement(CurrentPriceProperty, CurrentPrice, TextBlock.TextProperty, "CurrentPrice");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ISHES proxy = ConnectToSHES();
            List<Dictionary<String, Double>> measurementsForDay = proxy.GetInfoForDate(GraphDate.SelectedValue.ToString());

            Dictionary<String, Double> solarPanelProduction = measurementsForDay[0];
            ((LineSeries)chart.Series[0]).ItemsSource = solarPanelProduction;

            Dictionary<String, Double> batteryConsumptionProduction = measurementsForDay[1];
            ((LineSeries)chart.Series[1]).ItemsSource = batteryConsumptionProduction;

            Dictionary<String, Double> powerFromUtility = measurementsForDay[2];
            ((LineSeries)chart.Series[2]).ItemsSource = powerFromUtility;

            Dictionary<String, Double> totalConsumption = measurementsForDay[3];
            ((LineSeries)chart.Series[3]).ItemsSource = totalConsumption;

            Dictionary<String, Double> powerPrice = measurementsForDay[4];
            ((LineSeries)chart.Series[4]).ItemsSource = powerPrice;
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
                    CurrentPriceProperty = String.Format($"Power price: {utilityProxy.GetPowerPrice()} [$/kWh]");

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
