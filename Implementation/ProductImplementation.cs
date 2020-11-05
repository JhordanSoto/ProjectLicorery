using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Interfaces;
using MySql.Data.MySqlClient;

namespace Implementation
{
    public class ProductImplementation : IProduct
    {
        string query = "";
        public int Delete(Product generic)
        {
            query = @"UPDATE user SET status = 0 WHERE idUser = @idUser; ";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idProduct", generic.idProduct);
                cmd.Parameters.AddWithValue("@idUser", generic.idUser );
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int Insert(Product generic)
        {
            query = @"insert into User (UserName,Password,TypeUser,Phone,Address,Name,LastName) 
                      values(@Username, @Password, @TypeUser, @Phone, @Address, @Name, @LastName)";
            //try
             //{
                 MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
               /*  cmd.Parameters.AddWithValue("@Username", generic.userName);
                 cmd.Parameters.AddWithValue("@Password", generic.password);
                 cmd.Parameters.AddWithValue("@TypeUser", generic.typeUser);
                 cmd.Parameters.AddWithValue("@Phone", generic.phone);
                 cmd.Parameters.AddWithValue("@Address", generic.address);
                 cmd.Parameters.AddWithValue("@Name", generic.name);
                 cmd.Parameters.AddWithValue("@LastName", generic.lastName);
                 return DBImplementation.ExecuteBasicCommand(cmd);
             }
             catch (Exception ex)
             {

                 throw ex;
             }*/
            return DBImplementation.ExecuteBasicCommand(cmd);
        }

        public DataTable Select()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT p.idProduct 'Nro', p.detail as 'Detalle',p.Quantity 'Cantidad Del Prodcuto',p.PriceBuy 'Precio De Compra',p.PriceSale 'Precio Para Vender' 
                             FROM product p";
            MySqlCommand cmd;
            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                dt = DBImplementation.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }
        public Product Get(int id)
        {
            Product res = null;

            string query = @" SELECT idProduct, detail,   Quantity,   p.PriceSale,  p.PriceBuy  , c.NameCategory
                              FROM product p inner join category c on p.idcategoria = c.idcategory
                              WHERE IdProduct=@id";

            MySqlCommand cmd = null;
            MySqlDataReader dr = null;

            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = DBImplementation.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {

                    res = new Product(int.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()), double.Parse(dr[3].ToString()), double.Parse(dr[4].ToString()), dr[5].ToString());
                }

            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {
                dr.Close();
                cmd.Connection.Close();
            }

            return res;
        }

        public DataTable Selectv()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT p.idProduct 'Nro', p.detail,p.Quantity,p.PriceBuy,p.PriceSale,c.nameCategory, RegistrationDate 
                             FROM bddlicoreria.product p inner join category c on p.idCategoria=c.IdCategory;";
            MySqlCommand cmd;
            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                dt = DBImplementation.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        public int Update(Product generic)
        {
            query = @"UPDATE User SET Username = @Username,Password = @Password,TypeUser = @TypeUser,Phone = @Phone,Address = @Address,Name = @Name,LastName = @LastName,
                      UpdateDate =CURRENT_TIMESTAMP() WHERE idUser = @idUser ";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
               /* cmd.Parameters.AddWithValue("@IdUser", generic.idUser);
                cmd.Parameters.AddWithValue("@Username", generic.userName);
                cmd.Parameters.AddWithValue("@Password", generic.password);
                cmd.Parameters.AddWithValue("@TypeUser", generic.typeUser);
                cmd.Parameters.AddWithValue("@Phone", generic.phone);
                cmd.Parameters.AddWithValue("@Address", generic.address);
                cmd.Parameters.AddWithValue("@Name", generic.name);
                cmd.Parameters.AddWithValue("@LastName  ", generic.lastName);*/
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable Search(string textToSearch)
        {
            DataTable res = new DataTable();
            string query = @"SELECT p.idProduct 'Nro', p.detail as 'Detalle',p.Quantity 'Cantidad Del Prodcuto',p.PriceBuy 'Precio De Compra',p.PriceSale 'Precio Para Vender' 
                             FROM product p
                             WHERE p.detail  LIKE @texto and p.status=1";
            MySqlCommand cmd;
            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@texto", "%" + textToSearch + "%");
                res = DBImplementation.ExecuteDataTableComand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }

        public DataTable SearchingSale(string txt)
        {
            DataTable res = new DataTable();
            string query = @"SELECT p.idProduct 'Nro', p.detail,p.Quantity,p.PriceBuy,p.PriceSale,c.nameCategory, RegistrationDate 
                             FROM bddlicoreria.product p inner join category c on p.idCategoria=c.IdCategory
                             WHERE p.detail  LIKE @texto and p.status=1";
            MySqlCommand cmd;
            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@texto", "%" + txt + "%");
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
