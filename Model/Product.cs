using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public int idProduct { get; set; }
        public string detail { get; set; }
        public byte quantity { get; set;}
        public  double priceSale { get; set; }
        public  double priceBuy { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime updateDate { get; set; }
        public int idCategory { get; set; }
        public int idUser { get; set; }
        public byte status { get; set; }
        public string nameCategory { get; set; }
        public Product(int idProduct, string detail, byte quantity, double priceSale, double priceBuy, DateTime registrationDate, DateTime updateDate, int idCategory,byte status)
        {
            this.idProduct=idProduct;    
            this.detail=detail;
            this.quantity=quantity;
            this.priceSale=priceSale;
            this.priceBuy=priceBuy;
            this.registrationDate=registrationDate;
            this.updateDate=updateDate;
            this.idCategory=idCategory;
            this.status=status;
        }
        public Product(int idProduct,string detail, byte quantity, double priceSale, double priceBuy, string nameCategory)
        {
            this.idProduct = idProduct;
            this.detail = detail;
            this.quantity = quantity;
            this.priceSale = priceSale;
            this.priceBuy = priceBuy;
            this.nameCategory = nameCategory;
            this.idUser = idUser;
        }

    }
}
