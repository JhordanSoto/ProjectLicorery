using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Person
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public byte status { get; set; }
        public int phone { get; set; }
        public DateTime registerDate { get; set; }
        public DateTime updateDate { get; set; }
        public string image { get; set; }

     
    }
}
