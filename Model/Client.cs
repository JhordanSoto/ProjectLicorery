using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client : Person
    {

        public int idClient { get; set; }
        public byte idUser { get; set; }
        public double credit { get; set; }
        public string zone { get; set; }
        public Client()
        {

        }
        public Client(double credit, string zone,byte idUser, string name, string lastName, string address, int phone) 
        {
            this.credit = credit;
            this.zone = zone;
            this.idUser = idUser;
            this.address = address;
            this.phone = phone;
            this.name = name;
            this.address = address;
            this.lastName = lastName;

        }
        public Client(int idClient, string name, string lastName, double credit, int phone, string zone, string address, byte idUser)
        {
            this.idClient = idClient;
            this.name = name;
            this.lastName = lastName;
            this.credit = credit;
            this.phone = phone;
            this.zone = zone;
            this.idUser = idUser;
            this.address = address;
   

        }

    }
}
