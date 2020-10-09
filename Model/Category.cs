using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category
    {
        public int idCategory { get; set; }
        public string nameCategory { get; set; }
        public byte status { get; set; }
        public DateTime registerDate { get; set; }
        public DateTime updateDate { get; set; }
        public byte idUser { get; set; }
        public Category(int idCategory, string nameCategory, byte status, DateTime registerDate, DateTime updateDate)
        {
            this.idCategory=idCategory;
            this.nameCategory=nameCategory;
            this.status=status;
            this.registerDate=registerDate;
            this.registerDate=registerDate;
        }
        public Category(int idCategory, string nameCategory, byte status, DateTime registerDate)
        {
            this.idCategory = idCategory;
            this.nameCategory = nameCategory;
            this.status = status;
            this.registerDate = registerDate;
            this.registerDate = registerDate;
        }

        public Category(string nameCategory, byte idUser)
        {
        
            this.idUser = idUser;
            this.nameCategory = nameCategory;
        }
        public Category(int idCategory,string nameCategory,byte idUser)
        {
            this.idCategory = idCategory;
            this.idUser = idUser;
            this.nameCategory = nameCategory;
        }
    }
}
