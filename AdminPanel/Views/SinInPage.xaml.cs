using AdminPanel.Model;
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

namespace AdminPanel.Views
{
    /// <summary>
    /// Логика взаимодействия для SinInPage.xaml
    /// </summary>
    public partial class SinInPage : Page
    {
        public SinInPage()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.Login == TxbLogin.Text && u.Password == TxbPassword.Text);

            if (CurrentUser != null)
            {

                if (CurrentUser.RolesId == 1)
                {
                    NavigationService.Navigate(new DataPage());
                }
                else
                {
                    MessageBox.Show("Вы не являетесь админом", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
              
            }
            else
            {
                MessageBox.Show("Такой записи нет в БД", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
