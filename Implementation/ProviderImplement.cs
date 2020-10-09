using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Model;

namespace Implementation
{
    public class ProviderImplement : IProvider
    {
        string query = "";
        public int Delete(Provider generic)
        {
            query = @"UPDATE provider SET status = 0,UpdateDate= current_timeStamp() WHERE idprovider = @idcategory; ";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idCategory", generic.idProvider);
                cmd.Parameters.AddWithValue("@idUser", 1);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public Provider Get(int id)
        {
            Provider res = null;

            string query = @"SELECT idProvider,Businessname,nit,address,Phone,idUser FROM Provider WHERE idProvider=@id";

            MySqlCommand cmd = null;
            MySqlDataReader dr = null;

            try
            {
                cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = DBImplementation.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res = new Provider(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()),dr[3].ToString(), int.Parse(dr[4].ToString()), int.Parse(dr[5].ToString()));
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

        public int Insert(Provider generic)
        {
            query = @"insert into provider (businessName,Nit,Address,Phone,IdUser) 
                    values (@bussinessName,@Nit,@Address,@Phone,@IdUser)";
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@bussinessName", generic.businessName);
                cmd.Parameters.AddWithValue("@Nit", generic.nit);
                cmd.Parameters.AddWithValue("@Address", generic.address);
                cmd.Parameters.AddWithValue("@Phone", generic.phone);
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
            string query = @" SELECT p.idProvider,p.Businessname,p.nit,p.Address,p.Phone,if(p.status=1,'activo','inactivo')as 'estado', u.Username as 'register by'
                            FROM provider p inner join User u on p.IdUser=u.IdUser";
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

        public int Update(Provider generic)
        {
            query = "update provider set BusinessName=@BussinessName,Nit=@Nit,Address=@Address,Phone=@Phone,IdUser=@IdUser,UpdateDate=current_timestamp() where idProvider=@idProvider"; 
            try
            {
                MySqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idProvider", generic.idProvider);
                cmd.Parameters.AddWithValue("@bussinessName", generic.businessName);
                cmd.Parameters.AddWithValue("@Nit", generic.nit);
                cmd.Parameters.AddWithValue("@Address", generic.address);
                cmd.Parameters.AddWithValue("@Phone", generic.phone);
                cmd.Parameters.AddWithValue("@idUser", generic.idUser);
                return DBImplementation.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
