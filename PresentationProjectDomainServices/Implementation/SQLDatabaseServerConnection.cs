using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationProjectDomainDb
{
    public class SQLDatabaseServerConnection
    {
        public static DataTable ExecuteSQL(string sql, string connectionString)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataAdapter adapter = default(SqlDataAdapter);
            DataTable tb = new DataTable();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                adapter = new SqlDataAdapter(sql, connectionString);
                adapter.Fill(tb);

                connection.Close();
                connection = null;
                return tb;
            }
            catch(Exception ex) {

                MessageBox.Show("An error occured: " + ex.Message,
                    "SQL Server connection failed: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb = null;
            }

            return tb;
        }

        public static string ExecuteSQLByCmd(string sql, string connectionString, string value)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            var result = string.Empty;

            connection.Open();

            try
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = String.Format("{0}", reader[value]);
                    }

                    connection.Close();
                    return result;
                }
            }
            catch
            {
                connection.Close();
                return result;
            }

        }
    }
}
