using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace Interfaces
{
    public interface IUser : IDao<User>
    {
        DataTable login (string username, string password);
    }
}
