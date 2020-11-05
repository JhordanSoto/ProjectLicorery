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
using Implementation;
using System.Data;

namespace ProjectLicoreryIncos
{
    /// <summary>
    /// Lógica de interacción para SaleWin.xaml
    /// </summary>
    public partial class SaleWin : Window
    {
        Product product;
        double total=0;
        ProductImplementation productImplement;
        User user;
        List<ProductSale> list = new List<ProductSale>();
        List<int> listid = new List<int>();
        ProductSale productSale;
        ClientImplement clientImplement;
        string name;
        public SaleWin(User user1)
        {
            user = user1;
            InitializeComponent();
            LoadDataGrid();
        }

        void LoadDataGrid()
        {
            try
            {
                productImplement = new ProductImplementation();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = productImplement.Selectv().DefaultView;
                //dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void clean()
        {
            //txt_client.Clear();
            txt_Quantity.Clear();
        }


        private void btn_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                try
                {
                    product = null;
                    DataRowView d = (DataRowView)dgvDatos.SelectedItem;
                    int id = int.Parse(d.Row.ItemArray[0].ToString());
                    productImplement = new ProductImplementation();
                    product = productImplement.Get(id);
                    if (product != null)
                    {
                        if (product.quantity > 0)
                        {
                            txt_Quantity.Text = "1";
                            txt_UnitPrice.Text = Convert.ToString(product.priceSale);
                        }
                        else {
                            MessageBox.Show("There is not stock");
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        void loaddata(List<ProductSale> lista)
        {
            try
            {
                dgvDatosSaled.ItemsSource = null;
                dgvDatosSaled.ItemsSource = list;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (product.quantity - int.Parse(txt_Quantity.Text) > 0)
            {
                productSale = new ProductSale(product.detail, byte.Parse(txt_Quantity.Text), product.priceSale, product.nameCategory, name, byte.Parse(txt_Quantity.Text) * product.priceSale);
                if (list.Contains(productSale))
                {
                    MessageBox.Show("It was inserted before");
                }
                else
                {
                    if (txt_UnitPrice.Text == " ")
                    {
                        MessageBox.Show("Error Select one item");
                    }
                    else
                    {
                        list.Add(productSale);
                        double aux = byte.Parse(txt_Quantity.Text) * product.priceSale;
                        total = total + aux;
                        txt_Total.Text = total.ToString();
                        clean();
                        cbx_client.Text = "";
                        txt_UnitPrice.Clear();
                        productSale = null;
                        product = null;
                        loaddata(list);
                    }
                    
                }
            }
            else {
                MessageBox.Show("Stock can not supplied that");
                clean();
            }
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            dgvDatosSaled.ItemsSource = null;
        }

        private void txt_searchh_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_searchh.Text == "")
            {
                LoadDataGrid();
            }
            else
            {
                if (txt_searchh.Text.Length >= 3)
                {
                    BuscarProduct();
                }
                else
                {
                    LoadDataGrid();
                }
            }
        }
        void BuscarProduct()
        {
            try
            {
                productImplement = new ProductImplementation();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = productImplement.Search(txt_searchh.Text.Trim()).DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cbx_client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbx_client_TextInput(object sender, TextCompositionEventArgs e)
        {
        }
      
        void BuscarCliente()
        {
            try
            {
                string aux = cbx_client.Text;
                clientImplement = new ClientImplement();
                cbx_client.ItemsSource = clientImplement.Search(cbx_client.Text).DefaultView;
                cbx_client.Text = aux;
                cbx_client.DisplayMemberPath = "ci";
                cbx_client.SelectedValue = "nro";
                cbx_client.SelectedValue = "Nombre";


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cbx_client_TextChanged(object sender, RoutedEventArgs e)
        {
            if (cbx_client.Text.Length >= 5)
            {
                BuscarCliente();
            }

        }

        private void cbx_client_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void cbx_client_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count == 0)
                {

                }
                DataRowView row = (DataRowView)e.AddedItems[0];
                name = row["Nombre"].ToString();

            }
            catch (Exception ex)
            {

            }
            
        }
    }
    
}
