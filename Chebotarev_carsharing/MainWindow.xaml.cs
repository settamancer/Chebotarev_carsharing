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
        private Image firstButton;
        public MainWindow()
        {
            InitializeComponent();
            LoadPuzzle();
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
            if (txtPassword.SecurePassword.Length > 0)
            {
                lblPasswordHint.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblPasswordHint.Visibility = Visibility.Visible;
            }
        }

        private void LoadPuzzle()
        {
            var pices = Enumerable.Range(1, 4).OrderBy(x => new Random().Next()).ToList();
            pices.ForEach(x =>
            {
                var img = new Image
                {
                    Source = new BitmapImage(new Uri($"Images/{x}.png", UriKind.Relative)),
                    Tag = x,
                    Stretch = Stretch.Fill
                };
                img.MouseLeftButtonUp += Pices_Click;

                PuzzleGrid.Children.Add(img);
            });
        }

        private void Pices_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Image clicked)
            {
                if (firstButton == null)
                {
                    firstButton = clicked;
                    firstButton.Opacity = 0.5;
                    return;
                }
                if (clicked != firstButton)
                {
                    (firstButton.Source, clicked.Source) = (clicked.Source, firstButton.Source);
                    (firstButton.Tag, clicked.Tag) = (clicked.Tag, firstButton.Tag);
                }

                firstButton.Opacity = 1;
                firstButton = null;
                CheckPuzzle();
            }

        }

        private void CheckPuzzle() 
        {
            var expectedOrder = new int[] { 2, 1, 3, 4 };
            if (PuzzleGrid.Children.OfType<Image>()
                    .Select((img, i) => i + 1 == (int)img.Tag)
                    .All(x => x))
            {
                MessageBox.Show("Капча решена!");
            }       
             
        }
    }

}
