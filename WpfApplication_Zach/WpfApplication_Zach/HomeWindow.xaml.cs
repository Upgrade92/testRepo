using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WpfApplication_Zach
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\14632\source\repos\Upgrade92\testRepo\WpfApplication_Zach\WpfApplication_Zach\Database1.mdf;Integrated Security=True");

            try
            {
                connection.Open();

                string querry = "SELECT * FROM [Table]";
                SqlDataAdapter sda = new SqlDataAdapter(querry, connection);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                sda.Fill(ds, "Table");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listBox.Items.Add(Convert.ToString(dr[1].ToString()) + " " + Convert.ToString(dr[2].ToString()));
                }
            }
            finally
            {
                connection.Close();
            }
        }

       

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
                      
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(listBox.SelectedItem.ToString()+" deleted");
            }
            catch (System.NullReferenceException) { }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            string str = listBox.ToString();
            string username = listBox.SelectedItem.ToString().Substring(0, char.IsWhiteSpace());
            int i = str.IndexOf<char>(c => !char.IsWhiteSpace(c));
            string password = "";
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\14632\source\repos\Upgrade92\testRepo\WpfApplication_Zach\WpfApplication_Zach\Database1.mdf;Integrated Security=True");
                connection.Open();

                string querry = "DELETE * FROM [Table] WhereUsername = '" + username + "' AND Password = '" + password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, connection);

            }
            catch (SqlException) { }


            try
            {
                listBox.Items.RemoveAt(listBox.Items.IndexOf(listBox.SelectedItem));
            }
            catch(System.ArgumentOutOfRangeException) { }

        }
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
