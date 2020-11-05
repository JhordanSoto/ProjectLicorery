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
using System.Data;
using Model;
using Implementation;
using Microsoft.Win32;
using System.IO;

namespace ProjectLicoreryIncos
{
    /// <summary>
    /// Lógica de interacción para ProductWin.xaml
    /// </summary>
    public partial class ProductWin : Window
    {
        Product product;
        ProductImplementation productImplement;
        User user;
        string pathsource = "";
        string pathdestiny = @"C:\Users\Casa\Documents\Visual Studio 2015\Projects\ProjectLicoreryIncos\ProjectLicoreryIncos\Resources\";
        string filename = "";
        public ProductWin(User user1)
        {
            user = user1;
            InitializeComponent();
            LoadDataGrid();
            if (user.typeUser != "Admin")
            {
                btnDelete.Visibility = Visibility.Collapsed;
            }
        }
        void LoadDataGrid()
        {
            try
            {
                productImplement = new ProductImplementation();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = productImplement.Select().DefaultView;
                //dgvDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void clean()
        {
            txt_details.Clear();
            txt_priceBuy.Clear();
            txt_Quantity.Clear();
            txt_priceSale.Clear();
        }

        private void btn_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pathsource != " ")
            {
                File.Copy(pathsource, pathdestiny + filename);
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_search.Text == "")
            {
                LoadDataGrid();
            }
            else
            {
                if (txt_search.Text.Length >= 2)
                {
                    BuscarCliente();
                }
                else
                {
                    LoadDataGrid();
                }
            }
        }
        void BuscarCliente()
        {
            try
            {
                productImplement = new ProductImplementation();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = productImplement.Search(txt_search.Text.Trim()).DefaultView;
                //dgvDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imagex.Source = new BitmapImage(fileUri);
                pathsource = fileUri.AbsolutePath;
                filename = System.IO.Path.GetFileName(fileUri.AbsolutePath);
            }
        }
    }
}
