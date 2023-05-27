using Ficon.Model;
using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Threading;

namespace Ficon.View
{
    /// <summary>
    /// Логика взаимодействия для CheckPropertyStatus.xaml
    /// </summary>
    public partial class CheckPropertyStatus : Page
    {
        PropertyStatusEnterprise property = new PropertyStatusEnterprise();
        public CheckPropertyStatus()
        {
            InitializeComponent();
            this.DataContext = property.PropertyStatusIndicators();
            
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (property._indicators.Count != 0)
            {
                property._indicators.Clear();
                listview.Items.Refresh();
                placeDiagram.Children.Clear();
                progress.Value = 0;
            }

            property.CalculateIndicators1TotalValueAssets(double.Parse(BeginBalanceValue.Text), double.Parse(EndBalanceValue.Text));
            property.CalculateIndicators2ResidualValueOfFixedAssets(double.Parse(BeginResidualValue.Text), double.Parse(BeginInitialValue.Text), double.Parse(EndResidualValue.Text), double.Parse(EndInitialValue.Text));
            property.CalculateIndicators3DepreciationRateOfFixedAssets(double.Parse(BeginDepreciationValue.Text), double.Parse(BeginInitialValue.Text), double.Parse(EndDepreciationValue.Text), double.Parse(EndInitialValue.Text));
           
            foreach(var p in property._indicators)
            {
                progress.Value += p.Mark;
            }
            listview.Items.Refresh();
            listview.ItemsSource = property._indicators;

            WpfPlot Chart = new WpfPlot();
            Chart.Width = 300;
            Chart.Height = 300;
            var dataX = new double[] { 1, 2 };
            var dataY = new double[] { property._indicators[0].Value1, property._indicators[0].Value2};
            string[] labels = { "Begin", "End" };
            var bar = Chart.Plot.AddBar(dataY,dataX);
            bar.ShowValuesAboveBars = true;
            Chart.Plot.XTicks(dataX, labels);
            Chart.Plot.SetAxisLimits(yMin: 0);
            Chart.Plot.Title("Total value of assets");
            Chart.Plot.XLabel("Time of the reporting period");
            Chart.Plot.YLabel("Indicators' value");
            Chart.Refresh();
            placeDiagram.Children.Add(Chart);

            WpfPlot Chart1 = new WpfPlot();
            Chart1.Width = 300;
            Chart1.Height = 300;
            var dataY1 = new double[] { property._indicators[1].Value1, property._indicators[1].Value2 };
            Chart1.Plot.AddScatter(dataX, dataY1);
            Chart.Plot.XTicks(dataX, labels);
            Chart1.Plot.Title("Residual value of fixed assets");
            Chart1.Plot.XLabel("Time of the reporting period");
            Chart1.Plot.YLabel("Indicators' value");
            Chart1.Refresh();
            placeDiagram.Children.Add(Chart1);

            WpfPlot Chart2 = new WpfPlot();
            Chart2.Width = 300;
            Chart2.Height = 300;
            var dataY2 = new double[] { property._indicators[2].Value1, property._indicators[2].Value2 };
            Chart2.Plot.AddScatter(dataX, dataY2);
            Chart2.Plot.Title("Depreciation rate of fixed assets");
            Chart2.Plot.XLabel("Time of the reporting period");
            Chart2.Plot.YLabel("Indicators' value");
            Chart2.Refresh();
            placeDiagram.Children.Add(Chart2);

        }

    }
}
