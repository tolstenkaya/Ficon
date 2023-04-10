using Ficon.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();

            user.Id = 1;
            Roles role = new Roles();
            role.Id = 2;
            role.Names = "user";
            user.Roles = role;
            user.FirstName = FirstName.Text;
            user.LastName = LastName.Text;
            user.DataBirthday = (DateTime)DateBirthday.SelectedDate;
            user.Login = Login.Text;
            user.Password = Password.Password.ToString();

            AppData.db.Users.Add(user);
           
            AppData.db.SaveChanges();
           
            MessageBox.Show("You Create New User");

        }
    }
}
