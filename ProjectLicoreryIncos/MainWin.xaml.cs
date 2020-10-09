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
using System.Windows.Shapes;

namespace ProjectLicoreryIncos
{
    /// <summary>
    /// Lógica de interacción para MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        ClientWin client;
        Products.CategoryWin category;
        public MainWin()
        {
            InitializeComponent();
        }

        private void btn_closemain(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            client = new ClientWin();
            client.Show();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_5(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_6(object sender, RoutedEventArgs e)
        {
            ProviderWin provider = new ProviderWin();
            provider.Show();
        }

        private void ListViewItem_Selected_7(object sender, RoutedEventArgs e)
        {
            category = new Products.CategoryWin();
            category.Show();
        }

        private void ListViewItem_Selected_8(object sender, RoutedEventArgs e)
        {          
            
        }

        private void ListViewItem_Selected_9(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
