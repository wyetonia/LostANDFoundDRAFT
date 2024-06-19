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

namespace LostANDFoundDRAFT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> admins = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();

            // mga admins
            admins.Add("antonia", "123");
            admins.Add("leila", "123");
            admins.Add("gabby", "123");
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = chkShowPassword.IsChecked == true ? txtPasswordShow.Text : txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Content = "Please enter username and password.";
                return;
            }

            if (admins.ContainsKey(username) && admins[username] == password)
            {
                Window2 window2 = new Window2(username);
                window2.Show();
                this.Close();
            }
            else
            {
                lblMessage.Content = "Invalid username or password.";
            }
        }

        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPassword.Visibility = Visibility.Collapsed;
            txtPasswordShow.Visibility = Visibility.Visible;
            txtPasswordShow.Text = txtPassword.Password;
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPassword.Visibility = Visibility.Visible;
            txtPasswordShow.Visibility = Visibility.Collapsed;
            txtPassword.Password = txtPasswordShow.Text;
        }
    }
}
