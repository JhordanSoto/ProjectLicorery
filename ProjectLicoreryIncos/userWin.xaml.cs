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
    /// Lógica de interacción para userWin.xaml
    /// </summary>
    public partial class userWin : Window
    {
        User user,aux;
        UserImplement userImplement;
        public userWin(User user1)
        {
            aux = user1;
            InitializeComponent();
            LoadDataGrid();
        }

        void cleantxt()
        {
            txt_name.Clear();
            txt_Address.Clear();
            txt_lasName.Clear();
            txt_Password.Clear();
            txt_UserName.Clear();
            txt_phone.Clear();
        }
        void LoadDataGrid()
        {
            try
            {
                userImplement = new UserImplement();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = userImplement.Select().DefaultView;
               // dgvDatos.Columns[0].Visibility = Visibility.Hidden;
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
                if ((txt_Address.Text == " ")&& (txt_lasName.Text == " ") && (txt_Password.ToString() == " ") && (txt_phone.Text == " ") && (txt_UserName.Text == " ") && (txt_name.Text == " ") )
                {
                    MessageBox.Show("Llene todos los campos");
                }
                else
                {
                    userImplement = new UserImplement();
                    int res = userImplement.Insert(new User(txt_UserName.Text, txt_Password.Password.ToString(), cbx_Zone.Text, int.Parse(txt_phone.Text), txt_Address.Text, txt_name.Text, txt_lasName.Text));
                    if (res > 0)
                    {
                        MessageBox.Show("Registro insertado con éxito.");
                        cleantxt();
                        LoadDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("No se insertaron registros");
                    }
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
                txt_Password.IsEnabled = false;
                userImplement = new UserImplement();
                user.name = txt_name.Text;
                user.lastName = txt_lasName.Text;
                user.userName = txt_UserName.Text;
                user.address = txt_Address.Text;
                user.typeUser = cbx_Zone.Text;
                user.phone = int.Parse(txt_phone.Text);
                int res = userImplement.Update(user);
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

                MessageBox.Show(ex.Message);
            }
        }
            
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

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
                    user = new User();
                    DataRowView d = (DataRowView)dgvDatos.SelectedItem;
                    int id = int.Parse(d.Row.ItemArray[0].ToString());
                    userImplement = new UserImplement();
                    user = userImplement.Get(id);
                    txt_lasName.Text = user.lastName;
                    txt_phone.Text = user.phone.ToString();
                    txt_name.Text = user.name;
                    txt_UserName.Text = user.userName;
                    txt_Address.Text = user.address;

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txt_Address_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]")  )
            {
                e.Handled = true;
            }
        }

        private void txt_Password_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txt_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void txt_lasName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
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
                userImplement = new UserImplement();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = userImplement.Search(txt_search.Text.Trim()).DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txt_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
