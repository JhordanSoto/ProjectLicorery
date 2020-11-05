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
    public class ClientImplement : IClient
    {
        string query = "";
        public int Delete(Client generic)
        {
            query = "UPDATE CLIENT SET status=0, UpdateDate=CURRENT_TIMESTAMP(), IdUser=@idUser where idClient=@idClient";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idClient", generic.idClient);
                cmd.Parameters.AddWithValue("@idUser", generic.idUser);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Insert(Client generic)
        {
            query = @"insert into client(address,Credit,phone,zone,iduser,name,lastname) 
                      values(@address,@credit,@phone,@zone,@idUser,@name,@lastName);";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@name", generic.name);
                cmd.Parameters.AddWithValue("@lastname", generic.lastName);
                cmd.Parameters.AddWithValue("@address", generic.address);
                cmd.Parameters.AddWithValue("@credit", generic.credit);
                cmd.Parameters.AddWithValue("@phone", generic.phone);
                cmd.Parameters.AddWithValue("@zone", generic.zone);
                cmd.Parameters.AddWithValue("@idUser", generic.idUser);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Client Get(int id)
        {
            Client res = null;

            string query = @"SELECT c.IdClient as Nro, c.Name,c.LastName,c.Credit,c.phone,c.Zone,c.address,c.idUser
                             FROM client c
                            WHERE idClient=@id";

            MySqlCommand cmd = null;
            MySqlDataReader dr = null;

            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = DBImplementation.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res = new Client(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(),double.Parse(dr[3].ToString()),int.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(),byte.Parse(dr[7].ToString()));
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
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT c.IdClient, c.Name,c.LastName,c.Credit,c.phone,c.Zone, if(c.status=1,'activo','inactivo')as 'estado',c.address, u.Username as 'register by'
                             FROM client c inner join User u on c.IdUser=u.IdUser";
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

        public int Update(Client generic)
        {
            query = "UPDATE Client SET Name=@name,LastName=@lastname,Address=@address,credit=@credit,phone=@phone,zone=@zone, UpdateDate=CURRENT_TIMESTAMP(), IDUSER=@idUser where idClient=@idClient";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@name", generic.name);
                cmd.Parameters.AddWithValue("@lastname", generic.lastName);
                cmd.Parameters.AddWithValue("@address", generic.address);
                cmd.Parameters.AddWithValue("@credit", generic.credit);
                cmd.Parameters.AddWithValue("@phone", generic.phone);
                cmd.Parameters.AddWithValue("@zone", generic.zone);
                cmd.Parameters.AddWithValue("@idUser", 1);
                cmd.Parameters.AddWithValue("@idClient", generic.idClient);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Search(string textToSearch)
        {
            DataTable res = new DataTable();
            string query = @"SELECT c.IdClient as 'nro', c.Name 'Nombre' ,c.LastName 'Apellidos',c.ci,c.Credit 'Credito',c.phone 'Telefono',c.Zone 'Zona', if(c.status=1,'activo','inactivo')as 'estado',c.address 'Direccion', u.Username as 'registrado por'
                             FROM client c inner join User u on c.IdUser=u.IdUser
                            WHERE c.ci LIKE @texto";
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

