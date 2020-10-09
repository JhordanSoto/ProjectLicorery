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
        public ProviderWin()
        {
            InitializeComponent();
            LoadDataGrid();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                providerImplement = new ProviderImplement();
                provider.businessName = txt_Bussinessname.Text;
                provider.nit = int.Parse(txt_nit.Text);
                provider.phone = int.Parse(txt_phone.Text);
                provider.address = txt_address.Text;
                int res = providerImplement.Update(provider);
                if (res > 0)
                {
                    MessageBox.Show("Registro modificado con éxito.");
                    LoadDataGrid();

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
                int res = providerImplement.Insert(new Provider(txt_Bussinessname.Text,int.Parse(txt_nit.Text),txt_address.Text,int.Parse(txt_phone.Text),1));
                if (res > 0)
                {
                    MessageBox.Show("insertado");
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("no insertado");
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
                }
                else
                {
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
    }
}
