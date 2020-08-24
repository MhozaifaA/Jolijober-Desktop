using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using Jober.Model;
using LiveCharts;
using LiveCharts.Wpf;

namespace Jober.View.Settings.StatisticsView.Charts
{
    /// <summary>
    /// Interaction logic for ChartAcceptJob.xaml
    /// </summary>
    public partial class ChartAcceptJob : UserControl
    {
        //public ConnectionDbContext Context;
        //private BackgroundWorker Worker = new BackgroundWorker();


       // public SeriesCollection seriesCollection { get; set; }
        //public string[] MonthLabels { get; set; }
        //public Func<double, string> YFormatter { get; set; }

        public ChartAcceptJob()
        {
            InitializeComponent();

            //Context = new ConnectionDbContext();

            //Worker.DoWork += worker_DoWork;
            //Worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            //load();


            //MonthLabels = DateTimeFormatInfo.CurrentInfo.MonthNames;
            //YFormatter = num => num.ToString("N");

            //seriesCollection = new SeriesCollection
            //{
            //    new LineSeries
            //    {
            //        Values = new ChartValues<double> { 3, 5, 7, 4 }
            //    },

            //    new StackedColumnSeries
            //    {
                    
            //        Values = new ChartValues<int> {5 , 5 , 6 , 2 },
            //        //StackMode = StackMode.Values,
            //        //Title = "Company1"

            //    }
            //    //new StackedColumnSeries
            //    //{
            //    //    Values = new ChartValues<int> {4, 5 ,6 ,8 },
            //    //    StackMode = StackMode.Values,
            //    //    Title = "Company2"

            //    //},
            //    //new StackedColumnSeries
            //    //{
            //    //    Values = new ChartValues<int> { },
            //    //    StackMode = StackMode.Values,
            //    //    Title = "Company3"

            //    //}
            //};


            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);
            //seriesCollection[2].Values.Add(0);

            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);
            //seriesCollection[1].Values.Add(0);

            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);
            //seriesCollection[0].Values.Add(0);


            DataContext = this;
        }
        public void load()
        {
            DialogHostWait.IsOpen = true;
            //if (!Worker.IsBusy)
            //    Worker.RunWorkerAsync();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            

        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //seriesCollection[0].Values[0] = int.Parse(seriesCollection[0].Values[0].ToString()) + 180;
            //seriesCollection[0].Values[1] = int.Parse(seriesCollection[0].Values[0].ToString()) + 10;
            //seriesCollection[0].Values[2] = int.Parse(seriesCollection[0].Values[0].ToString()) + 150;
            //seriesCollection[0].Values[3] = int.Parse(seriesCollection[0].Values[0].ToString()) + 10;
            //seriesCollection[0].Values[4] = int.Parse(seriesCollection[0].Values[0].ToString()) + 120;
            //seriesCollection[0].Values[5] = int.Parse(seriesCollection[0].Values[0].ToString()) + 107;
            //seriesCollection[0].Values[6] = int.Parse(seriesCollection[0].Values[0].ToString()) + 190;
            //seriesCollection[0].Values[7] = int.Parse(seriesCollection[0].Values[0].ToString()) + 10;
            //seriesCollection[0].Values[8] = int.Parse(seriesCollection[0].Values[0].ToString()) + 10;
            //seriesCollection[0].Values[9] = int.Parse(seriesCollection[0].Values[0].ToString()) + 10;
            //seriesCollection[0].Values[10] = int.Parse(seriesCollection[0].Values[0].ToString()) + 120;
            //seriesCollection[0].Values[11] = int.Parse(seriesCollection[0].Values[0].ToString()) + 101;

            DialogHostWait.IsOpen = false;


        }
    }
}
