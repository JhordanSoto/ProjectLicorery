using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace Interfaces
{
    public  interface IProvider:IDao<Provider>
    {
        DataTable Selectv(Provider generic);

    }
}
