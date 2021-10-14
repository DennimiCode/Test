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

namespace DemoDemo.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegButtonOnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.RegPage());
        }

        private void LoginButtonOnClick(object sender, RoutedEventArgs e)
        {
            string userLoginDB = Model.UsersEntities.GetContext().UserData
                .Select(user => user.UserLogin)
                .Select(login => login)
                .Where(login => login == LoginTextBox.Text).First();

            string userPasswordDB = Model.UsersEntities.GetContext().UserData
                .Select(user => user.UserPassword)
                .Select(password => password)
                .Where(password => password == PasswordBox.Password).First();

            if (userLoginDB == LoginTextBox.Text && userPasswordDB == PasswordBox.Password)
            {
                Manager.Login = userLoginDB;
                Manager.Password = userPasswordDB;
                Manager.MainFrame.Navigate(new Pages.UserPage());
            }
            else
            {
                MessageBox.Show("Не верный логин или пароль", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
