using Ficon.Model;
using Ficon.View;
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
using System.Security.Cryptography;

namespace Ficon
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            var x = GetHash(Password.Password.ToString());

            var current_user = AppData.db.Users.FirstOrDefault(user => user.Login == Login.Text && user.Password == x);
            var current_user_login = AppData.db.Users.FirstOrDefault(user => user.Login == Login.Text);
            if (current_user != null)
            {
                MessageBox.Show($"We're glad to see you, {Login.Text}", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new MainUsersPage());
            }
            else
            {
                if (current_user_login != null)
                {
                    MessageBox.Show($"Incorrect password. Try again!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("This account does not exist. You should register first!", "Notification", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
            }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUpPage());
        }
    }
}