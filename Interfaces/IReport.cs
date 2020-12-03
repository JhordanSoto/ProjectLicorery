using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Interfaces
{
    public interface IReport 
    {
        DataTable Search(string inicio, string final);
        DataTable SearchC(string inicio, string final,string Categoria);

    }
}
