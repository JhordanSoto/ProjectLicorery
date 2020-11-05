using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public byte idUser { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string typeUser { get; set; }
        public byte status { get; set; }
        public int phone { get; set; }
        public string image { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime updateDate { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public User()
        {

        }

        public User(byte idUser, string userName, string password, string typeUser, int phone, string image, string address, string name, string lastName)
        {
            this.idUser=idUser;
            this.userName=userName;
            this.password=password;
            this.typeUser=typeUser;
            this.phone=phone;
            this.image=image;
            this.address=address;
            this.name=name;
            this.lastName=lastName;

        }
        public User(string userName, string password, string typeUser, int phone, string address, string name, string lastName)
        {
            this.idUser = idUser;
            this.userName = userName;
            this.password = password;
            this.typeUser = typeUser;
            this.phone = phone;
            this.address = address;
            this.name = name;
            this.lastName = lastName;

        }

        public User(byte idUser, string userName,string typeUser, int phone, string address, string name, string lastName)
        {
            this.idUser = idUser;
            this.userName = userName;
            this.typeUser = typeUser;
            this.phone = phone;
            this.address = address;
            this.name = name;
            this.lastName = lastName;

        }

        public User(byte idUser, string typeUser)
        {
            this.idUser = idUser;
            this.typeUser = typeUser;

        }
    }
}
