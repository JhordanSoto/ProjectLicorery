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

namespace ProjectLicoreryIncos.Products
{
    /// <summary>
    /// Lógica de interacción para CategoryWin.xaml
    /// </summary>
    public partial class CategoryWin : Window
    {
        Category category;
        CategoryImplement categoryImplemnt;
        User user;
        public CategoryWin(User user1)
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
                categoryImplemnt = new CategoryImplement();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = categoryImplemnt.Select().DefaultView;
                //dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                categoryImplemnt = new CategoryImplement();
                if (categoryImplemnt.Selectv(new Category(txt_categoryName.Text, user.idUser)).Rows.Count == 0)
                {
                    int res = categoryImplemnt.Insert(new Category(txt_categoryName.Text, user.idUser));
                    if (res > 0)
                    {
                        MessageBox.Show("insertado");
                        LoadDataGrid();
                        txt_categoryName.Clear();

                    }
                    else
                    {
                        MessageBox.Show("no insertado");
                    }
                }
                else
                {
                    txt_categoryName.Clear();
                    MessageBox.Show("duplicado");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }


        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                try
                {
                    category = null;
                    DataRowView d = (DataRowView)dgvDatos.SelectedItem;
                    int id = int.Parse(d.Row.ItemArray[0].ToString());
                    categoryImplemnt = new CategoryImplement();
                    category = categoryImplemnt.Get(id);
                    if (category != null)
                    {
                        txt_categoryName.Text = Convert.ToString(category.nameCategory);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                categoryImplemnt = new CategoryImplement();
                category.nameCategory = txt_categoryName.Text;
                category.idUser = user.idUser;
                int res = categoryImplemnt.Update(category);
                if (res > 0)
                {
                    MessageBox.Show("Registro modificado con éxito.");
                    LoadDataGrid();
                    txt_categoryName.Clear();


                }
                else
                {
                    txt_categoryName.Clear();

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
            categoryImplemnt = new CategoryImplement();
            int res = categoryImplemnt.Delete(category);
            try
            {
                if (res > 0)
                {
                    MessageBox.Show(res + " Registro eliminado");
                    txt_categoryName.Clear();

                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("Error Inesperado");
                    txt_categoryName.Clear();

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

        private void txt_categoryName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
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
                    BuscarCategoria();
                }
                else
                {
                    LoadDataGrid();
                }
            }
        }
        void BuscarCategoria()
        {
            try
            {
                categoryImplemnt = new CategoryImplement();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = categoryImplemnt.Search(txt_search.Text.Trim()).DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}