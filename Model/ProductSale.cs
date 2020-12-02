using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductSale
    {
        public int nro { get; set; }
        public string Detalle { get; set; }
        public byte Cantidad { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }
        public double Importe { get; set; }
        public string Cliente { get; set; }
        public int newQuantity { get; set; }






        public ProductSale(int nro,string Detalle, byte Cantidad, double Precio, string Categoria, string Cliente,double Importe,int newQuantity)
        {
            this.nro = nro;
            this.Detalle = Detalle;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Categoria = Categoria;
            this.Cliente = Cliente;
            this.Importe = Importe;
            this.newQuantity = newQuantity;

        }
        public ProductSale(int nro, string Detalle, byte Cantidad, double Precio, string Categoria, string Cliente)
        {
            this.nro = nro;
            this.Detalle = Detalle;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Categoria = Categoria;
            this.Cliente = Cliente;
        }
    }
}
