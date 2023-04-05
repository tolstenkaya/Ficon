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
    /// Логика взаимодействия для AddValues.xaml
    /// </summary>
    public partial class AddValues : Page
    {
        public AddValues()
        {
            InitializeComponent();

            CmbRole.ItemsSource = AppData.db.Roles.ToList();

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Users people = new Users();

            people.Login = TxbLogin.Text;

            people.Password = TxbPassword.Text;


            var CurrentRole = CmbRole.SelectedItem as Roles;
            people.RolesId = CurrentRole.Id;


            AppData.db.Users.Add(people);
            AppData.db.SaveChanges();
            MessageBox.Show("You Create New User");
            NavigationService.GoBack();

        }
    }
}
