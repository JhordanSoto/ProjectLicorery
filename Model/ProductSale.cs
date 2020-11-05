using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductSale
    {
        public string Detalle { get; set; }
        public byte Cantidad { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }
        public double Importe { get; set; }
        public string Cliente { get; set; }



        public ProductSale(string Detalle, byte Cantidad, double Precio, string Categoria, string Cliente,double Importe)
        {
            this.Detalle = Detalle;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Categoria = Categoria;
            this.Cliente = Cliente;
            this.Importe = Importe;
        }
    }
}
