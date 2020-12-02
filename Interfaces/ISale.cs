using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Interfaces
{
     public class ISale : IDao<ProductSale>
    {
        public int Delete(ProductSale generic)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductSale generic)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string textToSearch)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(ProductSale generic)
        {
            throw new NotImplementedException();
        }
    }
}
