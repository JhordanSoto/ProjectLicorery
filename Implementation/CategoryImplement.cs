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
    public class CategoryImplement : ICategory
    {
        string query = "";
        public int Delete(Category generic)
        {
            query = @"UPDATE category SET status = 0 WHERE idcategory = @idcategory; ";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idCategory", generic.idCategory);
                cmd.Parameters.AddWithValue("@idUser", generic.idUser);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int Insert(Category generic)
        {
            query = "INSERT INTO CATEGORY (NameCategory,IdUser) VALUES (@nameCategory,@idUser)";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nameCategory", generic.nameCategory);
                cmd.Parameters.AddWithValue("@idUser", generic.idUser);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable Select()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT c.IdCategory as Nro, c.NameCategory ' Nombre Categoria', if(c.status=1,'activo','inactivo')as 'estado', u.Username as 'register by'
                             FROM category c inner join User u on c.IdUser=u.IdUser;";
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
        public Category Get(int id)
        {
            Category res = null;

            string query = @" SELECT idCategory,NameCategory,IdUser
                            FROM category
                            WHERE idCategory=@id";

            MySqlCommand cmd = null;
            MySqlDataReader dr = null;

            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = DBImplementation.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res = new Category(int.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()));
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

        public int Update(Category generic)
        {
            query = @"UPDATE category SET namecategory = @nameCategory, UpdateDate =CURRENT_TIMESTAMP(), IDUSER=@iduser WHERE idcategory = @idCategory ";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idCategory", generic.idCategory);
                cmd.Parameters.AddWithValue("@nameCategory", generic.nameCategory);
                cmd.Parameters.AddWithValue("@idUser", generic.idUser);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable Selectv(Category generic)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT c.IdCategory, c.NameCategory, if(c.status=1,'activo','inactivo')as 'estado', u.Username as 'register by'
                             FROM category c inner join User u on c.IdUser=u.IdUser where NameCategory = @name";
            MySqlCommand cmd;
            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@name", generic.nameCategory);
                dt = DBImplementation.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        public DataTable Search(string textToSearch)
        {

            DataTable res = new DataTable();
            string query = @"SELECT c.IdCategory, c.NameCategory, if(c.status=1,'activo','inactivo')as 'estado', u.Username as 'register by'
                             FROM category c inner join User u on c.IdUser=u.IdUser
                            WHERE c.NameCategory LIKE @texto and c.status=1";
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
    }
}
