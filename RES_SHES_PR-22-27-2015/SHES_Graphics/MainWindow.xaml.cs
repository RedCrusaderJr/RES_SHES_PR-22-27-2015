using Common;
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
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ISHES proxy = ConnectHelper.ConnectToSHES();
            List<Dictionary<String, Double>> measurementsForDay = proxy.GetInfoForDate(GraphDate.SelectedValue.ToString());

            Dictionary<String, Double> solarPanelProduction = measurementsForDay[0];
            ((LineSeries)chart.Series[0]).ItemsSource = solarPanelProduction;

            Dictionary<String, Double> batteryConsumptionProduction = measurementsForDay[1];
            ((LineSeries)chart.Series[1]).ItemsSource = batteryConsumptionProduction;

            Dictionary<String, Double> powerFromUtility = measurementsForDay[2];
            ((LineSeries)chart.Series[2]).ItemsSource = powerFromUtility;

            Dictionary<String, Double> powerToUtility = measurementsForDay[3];
            ((LineSeries)chart.Series[3]).ItemsSource = powerToUtility;

            Dictionary<String, Double> totalConsumption = measurementsForDay[4];
            ((LineSeries)chart.Series[4]).ItemsSource = totalConsumption;

            Dictionary<String, Double> powerPrice = measurementsForDay[5];
            ((LineSeries)chart.Series[5]).ItemsSource = powerPrice;

            Dictionary<String, Double> moneyBalance = measurementsForDay[6];
            ((LineSeries)chart.Series[6]).ItemsSource = moneyBalance;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                IUniversalClockService universalClockProxy = ConnectHelper.ConnectUniversalClock();
                TotalMinutes = universalClockProxy.GetTimeInMinutes();
                TimeSpan ts = TimeSpan.FromMinutes(TotalMinutes);

                IPowerPrice utilityProxy = ConnectHelper.ConnectUtility();

                Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                {
                    CurrentTimeProperty = String.Format($"{ts.Hours} : {ts.Minutes}");
                    CurrentPriceProperty = String.Format($"Power price: {utilityProxy.GetPowerPrice(universalClockProxy.GetTimeInHours())} [$/kWh]");

                    Int32 day = universalClockProxy.GetDay();
                    if (day - 1 != 0)
                    {
                        String newDayString = $"{day - 1}. dan od startovanja aplikacije";

                        if (!ListOfDays.Contains(newDayString))
                        {
                            ListOfDays.Add(newDayString);
                        }
                    }
                    else
                    {
                        String newDayString = $"Dan u kojem je startovana aplikacija";

                        if (!ListOfDays.Contains(newDayString))
                        {
                            ListOfDays.Add(newDayString);
                        }
                    }
                }));

                Thread.Sleep(Constants.MILISECONDS_IN_SECOND);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string parameter)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter));

        } 
        #endregion
    }
}
