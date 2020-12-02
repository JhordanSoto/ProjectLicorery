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

namespace ProjectLicoreryIncos
{
    /// <summary>
    /// Lógica de interacción para ProviderWin.xaml
    /// </summary>
    public partial class ProviderWin : Window
    {
        Provider provider;
        ProviderImplement providerImplement;
        User user;
        public ProviderWin(User user1)
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
                providerImplement = new ProviderImplement();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = providerImplement.Select().DefaultView;
                //dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void clean() {
            txt_address.Clear();
            txt_Bussinessname.Clear();
            txt_nit.Clear();
            txt_phone.Clear();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                providerImplement = new ProviderImplement();
                provider.businessName = txt_Bussinessname.Text;
                provider.nit = int.Parse(txt_nit.Text);
                provider.phone = int.Parse(txt_phone.Text);
                provider.address = txt_address.Text;
                provider.idUser = user.idUser;
                int res = providerImplement.Update(provider);
                if (res > 0)
                {
                    MessageBox.Show("Registro modificado con éxito.");
                    LoadDataGrid();
                    clean();

                }
                else
                {
                    MessageBox.Show("No se modificaron registros");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                providerImplement = new ProviderImplement();
                if (providerImplement.Selectv(new Provider(txt_Bussinessname.Text, int.Parse(txt_nit.Text), txt_address.Text, int.Parse(txt_phone.Text), user.idUser)).Rows.Count == 0)
                {
                    int res = providerImplement.Insert(new Provider(txt_Bussinessname.Text, int.Parse(txt_nit.Text), txt_address.Text, int.Parse(txt_phone.Text), user.idUser));
                    if (res > 0)
                    {
                        MessageBox.Show("insertado");
                        clean();
                        LoadDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("no insertado");
                    }
                }
                else
                {
                    MessageBox.Show("duplicado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            providerImplement = new ProviderImplement();
            int res = providerImplement.Delete(provider);
            try
            {
                if (res > 0)
                {
                    MessageBox.Show(res + " Registro eliminado");
                    LoadDataGrid();
                    clean();
                }
                else
                {
                    clean();
                    MessageBox.Show("Error Inesperado");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
                    provider = null;
                    DataRowView d = (DataRowView)dgvDatos.SelectedItem;
                    int id = int.Parse(d.Row.ItemArray[0].ToString());
                    providerImplement = new ProviderImplement();
                    provider = providerImplement.Get(id);
                    if (provider != null)
                    {
                        txt_Bussinessname.Text = Convert.ToString(provider.businessName);
                        txt_nit.Text = Convert.ToString(provider.nit);
                        txt_address.Text = Convert.ToString(provider.address);
                        txt_phone.Text = Convert.ToString(provider.phone);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txt_nit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if (character >= 48 && character <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_Bussinessname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_address_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_phone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if (character >= 48 && character <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_search.Text == "")
            {
                LoadDataGrid();
            }
            else
            {
                if (txt_search.Text.Length >= 3)
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
                providerImplement = new ProviderImplement();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = providerImplement.Search(txt_search.Text.Trim()).DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
