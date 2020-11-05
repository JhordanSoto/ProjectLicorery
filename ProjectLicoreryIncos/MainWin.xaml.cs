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
using Model;

namespace ProjectLicoreryIncos
{
    /// <summary>
    /// Lógica de interacción para MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        User user; 
        ClientWin client;
        Products.CategoryWin category;
        MainWindow mm;
        SaleWin sale;
        ProductWin product;
        public MainWin(User user1,MainWindow mw)
        {
            InitializeComponent();
            user = user1;
            mm = mw;
            if (user.typeUser != "Admin")
            {
                userlistitem.Visibility = Visibility.Collapsed;
            }
            
             
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
            client = new ClientWin(user);
            client.Show();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            sale = new SaleWin(user);
            sale.Show();
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            userWin userw = new userWin(user);
            userw.Show();
        }

        private void ListViewItem_Selected_5(object sender, RoutedEventArgs e)
        {
            product = new ProductWin(user);
            product.Show();
        }

        private void ListViewItem_Selected_6(object sender, RoutedEventArgs e)
        {
            ProviderWin provider = new ProviderWin(user);
            provider.Show();
        }

        private void ListViewItem_Selected_7(object sender, RoutedEventArgs e)
        {
            category = new Products.CategoryWin(user);
            category.Show();
        }

        private void ListViewItem_Selected_8(object sender, RoutedEventArgs e)
        {
            mm.Show();
            this.Close();
        }

        private void ListViewItem_Selected_9(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
