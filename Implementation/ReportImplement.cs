using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Interfaces;
using System.Data;
using MySql.Data.MySqlClient;
namespace Implementation
{
    public class ReportImplement : IReport
    {
        public DataTable  Search(string inicio, string final)
        {
            string query;
            DataTable res = new DataTable();
            if (inicio == "2")
            {
                query = @"SELECT concat(u.Name , ' ',u.Lastname) 'Vendido Por',p.Detail 'Producto',s.DateSale 'Fecha',s.QuantityOfProducts ' Cantidad',ifNull(s.Ci,'Sin Carnet') 'Al Cliente',s.Import 'Importe' 
                            FROM sale s inner join user u on s.IdUser=u.IdUser inner join product p on s.IdProduct = p.IdProduct    
                            WHERE DateSale BETWEEN '2020-11-26' AND '2020-11-26'";

            }
            else { 
             query = @"SELECT concat(u.Name , ' ',u.Lastname) 'Vendido Por',p.Detail 'Producto',s.DateSale 'Fecha',s.QuantityOfProducts ' Cantidad',ifNull(s.Ci,'Sin Carnet') 'Al Cliente',s.Import 'Importe' 
                            FROM sale s inner join user u on s.IdUser=u.IdUser inner join product p on s.IdProduct = p.IdProduct    
                            WHERE DateSale BETWEEN '2020-11-26' AND '2020-11-30'";
            }
            MySqlCommand cmd;
            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@start", inicio);
                cmd.Parameters.AddWithValue("@final", final);
                res = DBImplementation.ExecuteDataTableComand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }

        public DataTable SearchC(string inicio, string final, string Categoria)
        {
            string query;
            DataTable res = new DataTable();
            if (inicio == "2")
            {
                 query = @"SELECT concat(u.Name , ' ',u.Lastname) 'Vendido Por',p.Detail 'Producto',s.DateSale 'Fecha',s.QuantityOfProducts ' Cantidad',ifNull(s.Ci,'Sin Carnet') 'Al Cliente',s.Import 'Importe' 
                             FROM sale s inner join user u on s.IdUser=u.IdUser inner join product p on s.IdProduct = p.IdProduct inner join category c on p.idCategoria = c.IdCategory
                             WHERE s.DateSale BETWEEN '2020-11-25' AND '2020-11-26' AND c.NameCategory = @categoria;";
            }
            else {

                query = @"SELECT concat(u.Name , ' ',u.Lastname) 'Vendido Por',p.Detail 'Producto',s.DateSale 'Fecha',s.QuantityOfProducts ' Cantidad',ifNull(s.Ci,'Sin Carnet') 'Al Cliente',s.Import 'Importe' 
                             FROM sale s inner join user u on s.IdUser=u.IdUser inner join product p on s.IdProduct = p.IdProduct inner join category c on p.idCategoria = c.IdCategory
                             WHERE s.DateSale BETWEEN '2020-11-27' AND '2020-11-30' AND c.NameCategory = @categoria;";
            }
            MySqlCommand cmd;
            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@start", inicio);
                cmd.Parameters.AddWithValue("@final", final);
                cmd.Parameters.AddWithValue("@categoria", Categoria);
                res = DBImplementation.ExecuteDataTableComand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }
    }
}
