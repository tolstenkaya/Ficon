using System;
using System.Collections.Generic;
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
using Ficon.Model;
using System.ComponentModel;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace Ficon.View
{
    /// <summary>
    /// Логика взаимодействия для MainUsersPage.xaml
    /// </summary>
    public partial class MainUsersPage : Page
    {
        ObservableCollection<AssetClass> classes;
        public MainUsersPage()
        {
            classes=new ObservableCollection<AssetClass>(AssetClass.ConstructTestData());
            InitializeComponent();
        }

        private void PropertyStatus_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CheckPropertyStatus());
        }


        //private Canvas CreatePieChart()
        //{

        //    return canvas;
        //}


    }
}
