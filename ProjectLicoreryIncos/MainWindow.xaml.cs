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

namespace ProjectLicoreryIncos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            Products.CategoryWin win1 = new Products.CategoryWin();
            win1.Show();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            ClientWin win1 = new ClientWin();
            win1.Show();
        }

        private void btnProvider_Click(object sender, RoutedEventArgs e)
        {
            ProviderWin win1 = new ProviderWin();
            win1.Show();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn_close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_login(object sender, RoutedEventArgs e)
        {
            MainWin main = new MainWin();
            this.Hide();
            main.Show();
        }
    }
}
