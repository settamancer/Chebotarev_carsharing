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

namespace Chebotarev_carsharing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            // Если текст все еще "Логин", очищаем и делаем черным
            if (tb.Text == "Логин")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            // Если пользователь ничего не ввел, возвращаем подсказку
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = "Логин";
                tb.Foreground = Brushes.Gray;
            }
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.SecurePassword.Length > 0 )
            {
                lblPasswordHint.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblPasswordHint.Visibility = Visibility.Visible;
            }
        }
    }

}
