using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Provider:Person
    {
        public int idProvider { get; set; }
        public string businessName { get; set; }
        public int nit { get; set; }
        public int idUser { get; set; }

        public Provider(int idProvider, string businessName, int nit, string address, int phone, int idUser)
        {
            this.idProvider = idProvider;
            this.businessName = businessName;
            this.nit = nit;
            this.idUser = idUser;
            this.address = address;
            this.phone = phone;
            
        }
        public Provider(string businessName, int nit, string address, int phone, int idUser)
        {
            this.businessName = businessName;
            this.nit = nit;
            this.idUser = idUser;
            this.address = address;
            this.phone = phone;
            this.address = address;

        }
    }
}
