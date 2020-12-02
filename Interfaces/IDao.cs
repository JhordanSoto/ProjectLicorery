﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDao <T>
    {
        int Insert(T generic);
        int Update(T generic);
        int Delete(T generic);
        DataTable Select();
    }
}
