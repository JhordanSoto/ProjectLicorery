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

namespace ProjectLicoreryIncos.Sales
{
    /// <summary>
    /// Lógica de interacción para Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        public Invoice(int idClient,string total, string cambio,string ingreso,List<ProductSale> list,string ciC,string nombreC,string zonaC,string direccionC)
        {
            InitializeComponent();
            MontoCliente.Text = "$" + ingreso + ".00";
            CambioCliente.Text = "$" + cambio + ".00";
            TotalDinero.Text = "$" + total + ".00";
            FechaDeHoy.Text = DateTime.Today.ToString();
            Nombre.Text = "Nombre: "+ nombreC;
            Ci.Text = "Ci: " + ciC;
            Direccion.Text = "Direccion: " + direccionC;
            Zona.Text = "Zona: " + zonaC;
            foreach (ProductSale item in list)
            {
                Descripcion.Items.Add(item.Detalle);
                Cantidad.Items.Add(item.Cantidad);
                Precio.Items.Add(item.Precio);
                Subtotal.Items.Add(item.Importe);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
