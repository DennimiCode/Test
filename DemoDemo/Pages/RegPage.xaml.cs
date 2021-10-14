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
using DemoDemo.Model;

namespace DemoDemo.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void BackButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (Manager.MainFrame.CanGoBack)
                Manager.MainFrame.GoBack();
        }

        private void RegButtonOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.UserData user = new Model.UserData()
                {
                    FirstName = FirstNameTextBox.Text,
                    UserLogin = LoginTextBox.Text,
                    UserPassword = PasswordBox.Password
                };

                Model.UsersEntities.GetContext().UserData.Add(user);
                Model.UsersEntities.GetContext().SaveChangesAsync();

                MessageBox.Show("Вы были успешно зарегистрированы!", "Информация", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
                if (Manager.MainFrame.CanGoBack)
                    Manager.MainFrame.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Вы не были зарегистрированы!", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
