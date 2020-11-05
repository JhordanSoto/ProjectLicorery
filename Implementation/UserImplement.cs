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
    public class UserImplement : IUser
    {
        string query = "";
        public int Delete(User generic)
        {
            query = @"UPDATE user SET status = 0 WHERE idUser = @idUser; ";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idUser", generic.idUser);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int Insert(User generic)
        {
            query = @"insert into User (UserName,Password,TypeUser,Phone,Address,Name,LastName) 
                      values(@Username, @Password, @TypeUser, @Phone, @Address, @Name, @LastName)";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@Username", generic.userName);
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
            }
        }

        public DataTable Select()
        {
            DataTable dt = new DataTable();
            string query = @"select idUser as Nro, UserName  'Usuario', TypeUser 'Tipo de Usuario',Phone 'Telefono',Address 'Direccion',Name'Nombre',LastName 'Apellidos' from user";
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
        public User Get(int id)
        {
            User res = null;

            string query = @" select idUser, UserName 'Usuario', TypeUser 'Tipo de Usuario',Phone 'Telefono',Address 'Direccion',Name'Nombre',LastName 'Apellidos' from user
                            WHERE IdUser=@id";

            MySqlCommand cmd = null;
            MySqlDataReader dr = null;

            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = DBImplementation.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res = new User(byte.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), int.Parse(dr[3].ToString()), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
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

        public int Update(User generic)
        {
            query = @"UPDATE User SET Username = @Username,Password = @Password,TypeUser = @TypeUser,Phone = @Phone,Address = @Address,Name = @Name,LastName = @LastName,
                       , UpdateDate =CURRENT_TIMESTAMP() WHERE idUser = @idUser ";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@IdUser", generic.idUser);
                cmd.Parameters.AddWithValue("@Username", generic.userName);
                cmd.Parameters.AddWithValue("@Password", generic.password);
                cmd.Parameters.AddWithValue("@TypeUser", generic.typeUser);
                cmd.Parameters.AddWithValue("@Phone", generic.phone);
                cmd.Parameters.AddWithValue("@Address", generic.address);
                cmd.Parameters.AddWithValue("@Name", generic.name);
                cmd.Parameters.AddWithValue("@LastName  ", generic.lastName);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable login(string username, string password)
        {
            DataTable res = new DataTable();
            string query = @"SELECT idUser,typeuser  FROM user
                WHERE username=@primerApellido AND password=@ci AND status=1";
            MySqlCommand cmd;
            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@primerApellido", username);
                cmd.Parameters.AddWithValue("@ci", password);
                res = DBImplementation.ExecuteDataTableComand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        public DataTable Search(string textToSearch)
        {
            DataTable res = new DataTable();
            string query = @"select idUser as Nro, UserName  'Usuario', TypeUser 'Tipo de Usuario',Phone 'Telefono',Address 'Direccion',Name'Nombre',LastName 'Apellidos'
                             from user
                             WHERE UserName LIKE @texto";
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

