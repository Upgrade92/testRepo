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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication_Zach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            if(passwordBox.IsFocused == true)
            {
                passwordBoxWatermark.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordBoxWatermark.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Hidden;
            passwordTextBox.Visibility = Visibility.Visible;     
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Visible;
            passwordTextBox.Visibility = Visibility.Hidden;
        }

        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            passwordTextBox.Text = passwordBox.Password;
            IsEmptyPassword();
        }
        void PasswordTextChangedHandler(Object sender, RoutedEventArgs args)
        {
            passwordBox.Password = passwordTextBox.Text;
            IsEmptyPassword();
        }

        private void IsEmptyPassword()
        {
            if (passwordTextBox.Text.Equals(""))
            {
                passwordBoxWatermark.Visibility = Visibility.Visible;
            }
            else
            {
                passwordBoxWatermark.Visibility = Visibility.Hidden;
            }
        }

        void UsernameBoxChangedHandler(Object sender, RoutedEventArgs args)
        {
            if (usernameBox.Text.Equals(""))
            {
                usernameWatermark.Visibility = Visibility.Visible;
            }
            else
            {
                usernameWatermark.Visibility = Visibility.Hidden;
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text.ToString(); 
            string password= passwordBox.Password.ToString();
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\14632\source\repos\Upgrade92\testRepo\WpfApplication_Zach\WpfApplication_Zach\Database1.mdf;Integrated Security=True");

            try
            {
                connection.Open();
                
                string querry = "SELECT * FROM [Table] Where Username = '" + username + "' AND Password = '" + password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, connection);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                UserAccount user = new UserAccount(username, password, Convert.ToInt32(dt.Rows[0][3]));

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Login successfully!\n"+user.UserName+"\n"+user.Password+"\n"+user.Permission);
                    this.Hide();
                    HomeWindow home = new HomeWindow();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("invalid credentials!");
                }
            }
            finally
            {
                connection.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


    }
}
