using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Kontaktbuch_Zach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            
            InitializeComponent();
            ListNames();
        }

        private void DispData()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\14632\source\repos\Upgrade92\testRepo\Kontaktbuch_Zach\Kontaktbuch_Zach\Database.mdf;Integrated Security=True");
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Kontaktbuch_Zach.Properties.Settings.DatabaseConnectionString"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From [Table]" ;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Table");
                
                da.Fill(dt);
                grid.ItemsSource = dt.DefaultView;
                
                con.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        private void ListNames()
        {
            try
            {
                
                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            DispData();
            MessageBox.Show("Steine schlafen, Steine sind heute müde");
        }
    }
}
