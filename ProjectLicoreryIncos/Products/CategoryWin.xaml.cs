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
        public CategoryWin()
        {
            InitializeComponent();
            LoadDataGrid();
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
                int res = categoryImplemnt.Insert(new Category(txt_categoryName.Text, 1));
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
                int res = categoryImplemnt.Update(category);
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
            categoryImplemnt = new CategoryImplement();
            int res = categoryImplemnt.Delete(category);
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
    }
}

