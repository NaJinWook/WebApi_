using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class DataBase
    {
        MySqlConnection conn;

        public DataBase()
        {
            conn = GetConnection();
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = string.Format("host={0};uid={1};pwd={2};port={3};database={4}", "gdc3.gudi.kr", "root", "1234", "24002", "gudi");
                conn.Open();
                return conn;

            }
            catch
            {
                return null;
            }
        }

        public MySqlDataReader GetReader(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand(sql, conn);
                return comm.ExecuteReader();
            }
            catch
            {
                return null;
            }

        }

        public bool NonQuery(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand(sql, conn);
                comm.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
