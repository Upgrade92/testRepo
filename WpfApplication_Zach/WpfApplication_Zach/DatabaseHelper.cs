using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication_Zach
{
    class DatabaseHelper
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\14632\source\repos\Upgrade92\testRepo\WpfApplication_Zach\WpfApplication_Zach\Database1.mdf;Integrated Security=True";

        public string ConnectionString { get { return connectionString; } }
        public void InsertIntoQuerry()
        {

        }
    }
}
