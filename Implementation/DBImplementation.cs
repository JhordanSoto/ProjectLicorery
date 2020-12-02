using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Implementation
{
    class DBImplementation
    {
       static string connectionString = "server=localhost;database=bddlicoreria2;Uid=root;pwd=1234;Port=3306";
        public static MySqlCommand CreateBasicCommand()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            return cmd;
        }
        public static MySqlDataReader ExecuteDataReaderCommand(MySqlCommand cmd)
        {
            MySqlDataReader res = null;
            try
            {
                cmd.Connection.Open();
                res = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }
        public static DataTable ExecuteDataTableCommand(MySqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }
        public static MySqlCommand CreateBasicCommand(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }
        public static int ExecuteBasicCommand(MySqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
               return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public static DataTable ExecuteDataTableComand(MySqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
