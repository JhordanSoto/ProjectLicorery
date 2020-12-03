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
    public partial class SaleWin : Window
    {
        Product product;
        double total=0;
        int idClientee;
        ProductImplementation productImplement;
        User user;
        Sale sale;
        List<ProductSale> list = new List<ProductSale>();
        List<Sale> lista = new List<Sale>();
        ProductSale productSale , productSale1;
        ClientImplement clientImplement;
        string name,direccion,zona;
        SaleImplement saleImplement;

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

        /// <summary>
        /// To select a product from the datagrid in order to sale 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Upload in the datagrid saled
        /// </summary>
        /// <param name="lista"></param>
        void loaddata(List<ProductSale> lista)
        {
            try
            {
                dgvDatosSaled.ItemsSource = null;
                dgvDatosSaled.ItemsSource = list;
                dgvDatosSaled.Columns[0].Visibility = Visibility.Hidden;
                dgvDatosSaled.Columns[6].Visibility = Visibility.Hidden;
                dgvDatosSaled.Columns[7].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// button to upload to the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    if (productSale1 != null)
                    {
                        productSale = productSale1;
                        productSale.Cantidad = byte.Parse(txt_Quantity.Text);
                    }
                    else
                    {
                        if (name == " ")
                        {
                            productSale = new ProductSale(product.idProduct, product.detail, byte.Parse(txt_Quantity.Text), product.priceSale, product.nameCategory, name, byte.Parse(txt_Quantity.Text) * product.priceSale,product.quantity - int.Parse(txt_Quantity.Text));
                            if (cbx_client.Text == " ")
                            {
                                sale = new Sale(cbx_client.Text,user.idUser, product.idProduct, byte.Parse(txt_Quantity.Text),productSale.Importe);

                            }
                            else
                            {
                                sale = new Sale(cbx_client.Text, user.idUser, product.idProduct, byte.Parse(txt_Quantity.Text), productSale.Importe);
                            }
                        }
                        else
                        {
                            productSale = new ProductSale(product.idProduct, product.detail, byte.Parse(txt_Quantity.Text), product.priceSale, product.nameCategory, cbx_client.Text, byte.Parse(txt_Quantity.Text) * product.priceSale, product.quantity - int.Parse(txt_Quantity.Text));
                            if (cbx_client.Text == " ")
                            {
                                sale = new Sale(cbx_client.Text, user.idUser, product.idProduct, byte.Parse(txt_Quantity.Text), productSale.Importe);
                            }
                            else
                            {
                                sale = new Sale(cbx_client.Text, user.idUser, product.idProduct, byte.Parse(txt_Quantity.Text), productSale.Importe);
                            }
                        }
                     }
                    if (txt_UnitPrice.Text == " ")
                    {
                        MessageBox.Show("Error Select one item");
                    }
                    else
                    {
                      
                            list = changeItem(list, productSale);
                            lista = changeItemSale(lista, sale);
                            double aux = byte.Parse(txt_Quantity.Text) * int.Parse(txt_UnitPrice.Text);
                            calculate(list);
                            clean();
                            //cbx_client.Text = "";
                            cbx_client.IsEnabled = false;
                            txt_UnitPrice.Clear();
                            productSale = null;
                            product = null;
                            loaddata(list);
                            txt_Ingreso.IsEnabled = true;
                       
                    }
            }

            catch (Exception Ex)
            {

              //  MessageBox.Show(Ex.Message);
            }
        }

        /// <summary>
        /// Calculate the price of the sale
        /// </summary>
        /// <param name="listpr"> the list of products</param>
        void calculate(List<ProductSale> listpr) {

            total = 0;
            double aux = 0;
            foreach (ProductSale item in listpr)
            {
                aux = item.Cantidad * item.Precio;
                total += aux; 
            }
            txt_Total.Text = total.ToString();

        }
        /// <summary>
        /// cancel the sale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            dgvDatosSaled.ItemsSource = null;
            list.Clear();
        }

        /// <summary>
        /// to search a prodcut on the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Method that search the product
        /// </summary>
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

               // MessageBox.Show(ex.Message);
            }
        } 

        /// <summary>
        /// Method to search client
        /// </summary>
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
                cbx_client.SelectedValue = "Zona";
                cbx_client.SelectedValue = "Direccion";
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

        /// <summary>
        /// change the item 
        /// </summary>
        /// <param name="listpr"></param>
        /// <param name="prdSale"></param>
        /// <returns></returns>
        List<ProductSale> changeItem(List<ProductSale> listpr , ProductSale prdSale)
        {
            bool verification = false;
            foreach (ProductSale item in listpr )
            {
                if (item.nro == prdSale.nro)
                {
                    item.Cantidad = prdSale.Cantidad;
                    item.Importe = prdSale.Cantidad * prdSale.Precio;
                    verification = true;
                }
            }
            if (verification == false)
            {
                listpr.Add(prdSale);
            }
            return listpr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listpr"></param>
        /// <param name="prdSale"></param>
        /// <returns></returns>
        List<Sale> changeItemSale(List<Sale> listpr, Sale prdSale)
        {
            bool verification = false;
            foreach (Sale item in listpr)
            {
                if (item.idProduct == prdSale.idProduct)
                {
                    item.QuantityOfProducts = prdSale.QuantityOfProducts;
                    verification = true;
                }
            }
            if (verification == false)
            {
                listpr.Add(prdSale);
            }
            return listpr;
        }
        
        /// <summary>
        /// event to search the client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_client_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           
            if (cbx_client.Text.Length >= 5)
            {
                BuscarCliente();
            }
          
        }

        /// <summary>
        /// Selection changed from combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_client_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count == 0)
                {

                }
                DataRowView row = (DataRowView)e.AddedItems[0];
                name = row["Nombre"].ToString();
                zona = row["Zona"].ToString();
                direccion = row["Direccion"].ToString();
                idClientee = int.Parse(row["nro"].ToString());
            }
            catch (Exception ex)
            {

            }
            
        }

        /// <summary>
        /// to calculate the change of the client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Ingreso_TextChanged(object sender, TextChangedEventArgs e)
        {
            double cambio = 0;
            try
            {
                if (txt_Total.Text != " ")
                {
                    cambio = double.Parse(txt_Ingreso.Text) - double.Parse(txt_Total.Text);

                }
                txt_cambio.Text = cambio.ToString();
            }
            catch (Exception)
            {


            }
            
        }

        /// <summary>
        /// button to sale and print the invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (list.Count != 0)
                {
                    Sales.Invoice invoicewin = new Sales.Invoice(1, txt_Total.Text, txt_cambio.Text, txt_Ingreso.Text, list, cbx_client.Text, name, zona, direccion);
                    invoicewin.Show();
                    saleImplement = new SaleImplement();
                    foreach (ProductSale item in list)
                    {
                        saleImplement.Delete(item);
                    }
                    foreach (Sale item in lista)
                    {
                        saleImplement.Insert(item);
                    }
                    dgvDatosSaled.ItemsSource = null;
                    list.Clear();
                    this.Close();
                    txt_cambio.Text = "";
                    txt_Ingreso.Text = "";
                    cbx_client.IsEnabled = true;
                    txt_Total.IsEnabled = true;
                    txt_Total.Text = "  ";
                    txt_UnitPrice.Text = "";
                    txt_Quantity.Text = "";
                    cbx_client.Text = "";
                    MessageBox.Show("Venta Realizada");
                }
                else {
                    MessageBox.Show("Agregue elementos para vender");
                }


            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// eliminate from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnelimanteproduct_Click(object sender, RoutedEventArgs e)
        {
            int loo = 0;
            foreach (ProductSale item in list)
            {
                if (item.Detalle == productSale1.Detalle)
                {
                    list.RemoveAt(loo);
                    break;
                }
                loo++;
            }
            loaddata(list);
            productSale1 = null;
           
        }

        /// <summary>
        /// to fill client params
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_client_TextChanged(object sender, KeyEventArgs e)
        {
            if (cbx_client.Text != " ")
            {
                stackClientData.Visibility = Visibility.Visible;
                txt_nameClient.Text = name;
                txt_Address.Text = direccion;
                txt_ZoneClient.Text = zona;
                txt_ZoneClient.IsEnabled = false;
                txt_nameClient.IsEnabled = false;
                txt_Address.IsEnabled = false;
            }
            else
            {
                stackClientData.Visibility = Visibility.Hidden;
                txt_nameClient.Text = " ";
                txt_Address.Text = " ";
                txt_ZoneClient.Text = " ";

            }

        }

        private void cbx_client_DropDownClosed(object sender, EventArgs e)
        {
            if (cbx_client.Text != " ")
            {
                stackClientData.Visibility = Visibility.Visible;
                txt_nameClient.Text = name;
                txt_Address.Text = direccion;
                txt_ZoneClient.Text = zona;
                txt_ZoneClient.IsEnabled = false;
                txt_nameClient.IsEnabled = false;
                txt_Address.IsEnabled = false;
            }
            else {
                stackClientData.Visibility = Visibility.Hidden;
                txt_nameClient.Text = " ";
                txt_Address.Text = " ";
                txt_ZoneClient.Text = " ";

            }


        }

        private void dgvDatosSaled_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatosSaled.Items.Count > 0 && dgvDatosSaled.SelectedItem != null)
            {
                try
                {

                    productSale1 = (ProductSale) dgvDatosSaled.SelectedItem;
                    txt_Quantity.Text = productSale1.Cantidad.ToString();
                    txt_UnitPrice.Text = productSale1.Precio.ToString();
                    productSale1.Cantidad = byte.Parse(txt_Quantity.Text);
                   // product = productImplement.Get(productSale1.nro);
                }
                catch (Exception ex)
                {

                  //  MessageBox.Show(ex.Message);
                }
            }
        }
    }
    
}
