using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication_Zach
{
    class DatabaseHelper
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\14632\source\repos\Upgrade92\testRepo\WpfApplication_Zach\WpfApplication_Zach\Database1.mdf;Integrated Security=True";

        public string ConnectionString { get { return connectionString; } }
        public void NonQuerry(string querry)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnectionString);
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(querry, connection);
                SqlCommand cmd = new SqlCommand(querry, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(SqlException) { }
        }
    }
}
