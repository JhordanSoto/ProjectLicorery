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
    /// Lógica de interacción para ClientWin.xaml
    /// </summary>
    public partial class ClientWin : Window
    {
        Client client;
        ClientImplement clientImplement;
        public ClientWin()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void btn_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        void LoadDataGrid()
        {
            try
            {
                clientImplement = new ClientImplement();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = clientImplement.Select().DefaultView;
                // dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btn_login(object sender, RoutedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                try
                {
                    client = new Client();
                    DataRowView d = (DataRowView)dgvDatos.SelectedItem;
                    int id = int.Parse(d.Row.ItemArray[0].ToString());
                    clientImplement = new ClientImplement();
                    client = clientImplement.Get(id);
                    txt_address.Text = client.address;
                    txt_phone.Text = client.phone.ToString();
                    txt_Credit.Text = client.credit.ToString();
                    txt_lasName.Text = client.lastName;
                    txt_name.Text = client.name;

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clientImplement = new ClientImplement();
                int res = clientImplement.Insert(new Client(double.Parse(txt_Credit.Text), cbx_Zone.Text, 1, txt_name.Text, txt_lasName.Text, txt_address.Text, int.Parse(txt_phone.Text)));
                if (res > 0)
                {
                    MessageBox.Show("Registro insertado con éxito.");
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("No se insertaron registros");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                clientImplement = new ClientImplement();
                client.name = txt_name.Text;
                client.lastName = txt_lasName.Text;
                client.credit = double.Parse(txt_Credit.Text);
                client.address = txt_address.Text;
                client.phone = int.Parse(txt_phone.Text);
                int res = clientImplement.Update(client);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            clientImplement = new ClientImplement();
            int res = clientImplement.Delete(client);
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
    }
}
