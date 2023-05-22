using Ficon.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
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

namespace Ficon.View
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users user = new Users();

                user.Id = 1;
                user.Roles = AppData.db.Roles.FirstOrDefault(role => role.Names == "user");
                user.FirstName = FirstName.Text;
                user.LastName = LastName.Text;
                user.DataBirthday = (DateTime)DateBirthday.SelectedDate;
                user.Login = Login.Text;

                if (Password.Password == PasswordRepeat.Password)
                {
                    user.Password = GetHash(Password.Password.ToString());
                    AppData.db.Users.Add(user);

                    AppData.db.SaveChanges();

                    MessageBox.Show("You Create New User");
                    NavigationService.GoBack();
                }
                else
                {
                    Password.Background = new SolidColorBrush(Colors.Red);
                    PasswordRepeat.Background = new SolidColorBrush(Colors.Red);
                    PasswordRepeat.Password = "";
                    MessageBox.Show("Password mismatch!");
                }
                Password.Background = new SolidColorBrush(Colors.White);
                PasswordRepeat.Background = new SolidColorBrush(Colors.White);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage);
                    }
                }

            }
        }
    }
}
