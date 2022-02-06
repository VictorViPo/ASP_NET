using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_WPI_8_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MaterialCards : UserControl, INotifyPropertyChanged
    {

        public MaterialCards()
        {
            InitializeComponent();

            ColumnSeriesValues = new SeriesCollection
        {

            new ColumnSeries
        {
            Values = new ChartValues<double> { 10,20,30,40,50,60,70,80,90.100

        }

        }

};

            DataContext = this;

        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public SeriesCollection ColumnSeriesValues { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new
            PropertyChangedEventArgs(propertyName));
        }

        private void UpdateOnСlick(object sender, RoutedEventArgs e)
        {
            //TimePowerChart.Update(true);
        }
        public partial class MainWindow : Window
        {
            public MainWindow() => throw new NotImplementedException();

            private void Button_Click(object sender, RoutedEventArgs e)
            {
            }

        }

    }
}