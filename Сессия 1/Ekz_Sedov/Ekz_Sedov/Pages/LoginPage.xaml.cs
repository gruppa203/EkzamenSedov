using Ekz_Sedov.ApplicationData;
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

namespace Ekz_Sedov.Pages
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

        private void btnToComeIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = bdSedovEntities.GetContext().Users.FirstOrDefault(x => x.login == txbLogin.Text && x.password == psbPassword.Password);

                if (userObj == null)
                {
                    MessageBox.Show("Пользователь с таким логином и паролем не найден!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    AppFrame.MainFrame.Navigate(new MainMenu());
                    var roleObj = bdSedovEntities.GetContext().Users.FirstOrDefault(x => x.role == userObj.role);
                    App.Current.MainWindow.Title = roleObj.role + " " + userObj.FIO;
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка:" + Ex.Message.ToString(), "Критическая работа приложения", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
