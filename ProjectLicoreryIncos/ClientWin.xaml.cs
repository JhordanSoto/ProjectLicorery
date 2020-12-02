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
        User user;
        ClientImplement clientImplement;
        public ClientWin(User user1)
        {
            user = user1;
            InitializeComponent();
            LoadDataGrid();
            if (user.typeUser != "Admin")
            {
                btnDelete.Visibility = Visibility.Collapsed;
            }
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
                //dgvDatos.Columns[0].Visibility = Visibility.Hidden;
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

        void cleantxt()
        {
            txt_address.Clear();
            txt_Credit.Clear();
            txt_lasName.Clear();
            txt_name.Clear();
            txt_phone.Clear();

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
                int res = clientImplement.Insert(new Client(double.Parse(txt_Credit.Text), cbx_Zone.Text, user.idUser, txt_name.Text, txt_lasName.Text, txt_address.Text, int.Parse(txt_phone.Text)));
                if (res > 0)
                {
                    MessageBox.Show("Registro insertado con éxito.");
                    cleantxt();
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("No se insertaron registros");
                    cleantxt();
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
                client.idUser = user.idUser;
                client.phone = int.Parse(txt_phone.Text);
                int res = clientImplement.Update(client);
                if (res > 0)
                {
                    MessageBox.Show("Registro modificado con éxito.");
                    cleantxt();
                    LoadDataGrid();

                }
                else
                {
                    MessageBox.Show("No se modificaron registros");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("formato erroneo");
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
                    cleantxt();
                    LoadDataGrid();
                }
                else
                {
                    cleantxt();
                    MessageBox.Show("Error Inesperado");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("formato erroneo");
            }
        }

        private void txt_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txt_Credit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if (character >= 48 && character <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_lasName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
                e.Handled = false;
            else
                e.Handled = true;
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
                clientImplement = new ClientImplement();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = clientImplement.Search(txt_search.Text.Trim()).DefaultView;
               //dgvDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
