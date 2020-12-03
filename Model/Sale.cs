using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sale
    {
        public string ci { get; set; }
        public byte idUser { get; set; }
        public int idProduct { get; set; }

        public byte QuantityOfProducts { get; set; }

        public double Import { get; set; }


        public Sale(string ci, byte idUser, int idProduct, byte QuantityOfProducts,double Import)
        {
            this.idUser = idUser;
            this.ci = ci;
            this.idProduct = idProduct;
            this.QuantityOfProducts = QuantityOfProducts;
            this.Import = Import;

        }

            public Sale(byte idUser, int idProduct, byte QuantityOfProducts)
        {
            this.idUser = idUser;
            this.ci = ci;
            this.idProduct = idProduct;
            this.QuantityOfProducts = QuantityOfProducts;
        }


    }
}
