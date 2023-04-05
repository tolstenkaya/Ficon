using System;
using System.Collections;
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
using AdminPanel.Model;

namespace AdminPanel.Views
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
       
        public DataPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserGrid.ItemsSource = AppData.db.Users.ToList();
        }

        private void BtnBack_click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddValues());
        }

        private void Change_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delite_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы точно хотите удалить пользователя","Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentUser = UserGrid.SelectedItem as Users;
                AppData.db.Users.Remove(CurrentUser);
                AppData.db.SaveChanges();

                UserGrid.ItemsSource = AppData.db.Users.ToList();
                MessageBox.Show("Success");
            }
        }

        private void Serch_Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                UserGrid.ItemsSource = AppData.db.Users.Where(item => item.Login == Search_TBox.Text || item.Login.Contains(Search_TBox.Text)).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
