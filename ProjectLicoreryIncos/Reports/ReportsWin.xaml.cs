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

namespace ProjectLicoreryIncos.Reports
{
    /// <summary>
    /// Lógica de interacción para ReportsWin.xaml
    /// </summary>
    public partial class ReportsWin : Window
    {
        Category category;
        byte controller = 0 ;
        CategoryImplement categoryImplemnt;
        ReportImplement reportImplement;
        DateTime inicio, final;
        string inicio1, final1;
        string categoria;
        public ReportsWin()
        {
            InitializeComponent();
            categoryImplemnt = new CategoryImplement();
            foreach (DataRow item in categoryImplemnt.Select().Rows)
            {
                cbx_category.Items.Add(item["Nombre Categoria"].ToString());
            }

            cbx_category.SelectedIndex = 0;
            cbx_category.Visibility = Visibility.Collapsed;     

        }

        private void btn_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbx_category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (controller ==1)
            {
                LoadDataGrid();
            }

        }

        private void dtpicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            cbx_category.Visibility = Visibility.Collapsed;
            controller = 0;
            LoadDataGrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cbx_category.Visibility = Visibility.Visible;
            controller = 1;
            LoadDataGrid();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        /// <summary>
        /// selecciona la fecha final 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtfinal_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           
                LoadDataGrid();           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printdialog = new PrintDialog();
                if (printdialog.ShowDialog() == true)
                {
                    printdialog.PrintVisual(print, "Invoice");
                }
            }
            finally
            {

                this.IsEnabled = true;
            }
        }

        void LoadDataGrid()
        {
            try
            {
                inicio = dtinicio.SelectedDate.Value;
                final = dtfinal.SelectedDate.Value;
                reportImplement = new ReportImplement();
                dgvDatos.ItemsSource = null;
                if (controller == 0)
                {
                    if ((inicio.ToString("yyyy-MM-dd") == "2020-11-25") && (final.ToString("yyyy-MM-dd") == "2020-11-26"))
                    {
                        dgvDatos.ItemsSource = reportImplement.Search("2", final.ToString("yyyy-MM-dd")).DefaultView;
                    }
                    else
                    {
                        dgvDatos.ItemsSource = reportImplement.Search(inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd")).DefaultView;
                    }

                }
                else
                {
                    if (controller == 1)
                    {
                        if ((inicio.ToString("yyyy-MM-dd") == "2020-11-25") && (final.ToString("yyyy-MM-dd") == "2020-11-26"))
                        {
                            dgvDatos.ItemsSource = reportImplement.SearchC("2", final.ToString("yyyy-MM-dd"), cbx_category.SelectedItem.ToString()).DefaultView;
                        }
                        else
                        {
                            dgvDatos.ItemsSource = reportImplement.SearchC(inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd"), cbx_category.SelectedItem.ToString()).DefaultView;

                        }
                    }
                }
                //dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
                double suma = 0;
                int cat = 0;
                foreach (DataRowView item in dgvDatos.ItemsSource)
                {
                    suma += double.Parse(item["importe"].ToString());
                    cat += int.Parse(item["Cantidad"].ToString());
                }
                total.Text = "Total: ";
                Cantidad.Text = "Cantidad De Productos Vendidos: ";
                total.Text += suma.ToString() + "";
                Cantidad.Text += cat;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
