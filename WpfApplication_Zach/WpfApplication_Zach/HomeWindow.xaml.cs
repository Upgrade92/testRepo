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
            LoadList();
        } 

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            NewUser register = new NewUser();
            register.Show();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
                string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

                if (MessageBox.Show($"You Sure you want to delete {firstname} {lastname}?", "SafeDelete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(new DatabaseHelper().ConnectionString);
                        connection.Open();

                        string querry = $"DELETE FROM [TablePeople] WHERE Firstname = '{firstname}' AND Lastname ='{lastname}'";
                        SqlCommand cmd = new SqlCommand(querry, connection);
                        cmd.ExecuteNonQuery();
                        try
                        {
                            listBox.Items.RemoveAt(listBox.Items.IndexOf(listBox.SelectedItem));
                        }
                        catch (System.ArgumentOutOfRangeException) { }
                        connection.Close();
                    }
                    catch (SqlException) { }
                }
            }
            catch (NullReferenceException) { }
    }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void LoadList()
        {
            listBox.Items.Clear();
            SqlConnection connection = new SqlConnection(new DatabaseHelper().ConnectionString);
            try
            {
                connection.Open();

                string querry = "SELECT * FROM [TablePeople]";
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

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            listView.Items.Clear();
            if (listBox.SelectedItem != null) { 
            string firstname = listBox.SelectedItem.ToString().Split(' ')[0];
            string lastname = listBox.SelectedItem.ToString().Split(' ')[1];

            try
            {
                SqlConnection connection = new SqlConnection(new DatabaseHelper().ConnectionString);
                connection.Open();

                string querry = $"SELECT * FROM [TablePeople] WHERE Firstname = '{firstname}' AND Lastname ='{lastname}'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, connection);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                sda.Fill(ds, "Table");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listView.Items.Add($"Anrede: \t\t{GetTitle(Convert.ToString(dr[4].ToString()))}");
                    listView.Items.Add($"Vorname: \t{firstname}");
                    listView.Items.Add($"Nachname:\t{lastname}");
                    listView.Items.Add($"");
                    listView.Items.Add($"E-Mail:  \t\t{Convert.ToString(dr[3].ToString())}");
                    listView.Items.Add($"Geboren: \t{Convert.ToString(dr[5].ToString().Split(' ')[0])}");

                }
                connection.Close();
            }
            catch (SqlException) { }
            }
        }

        private string GetTitle(string gender)
        {
            if (gender.ToLower().Equals("weiblich"))
            {
                return "Frau";
            }
            else if (gender.ToLower().Equals("männlich"))
            {
                return "Herr";
            }
            else
            {
                return "Anrede";
            }
        }

        private void LoadList(object sender, RoutedEventArgs e)
        {
            LoadList();
        }
    }
}
