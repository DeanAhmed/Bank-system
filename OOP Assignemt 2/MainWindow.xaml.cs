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
using BIZ;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace OOP_Assignemt_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Hash h = new Hash();
        DAO d = new DAO();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUser.Text;
            string pass = h.HashData(txtPass.Password);

            SqlCommand cmd = d.OpenCon().CreateCommand();
            cmd.CommandText = "uspLogin";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Succesfully Logged in");
                lblPass.IsEnabled = false;
                lblUser.IsEnabled = false;
                txtPass.IsEnabled = false;
                txtUser.IsEnabled = false;
                btnLogin.IsEnabled = false;
                btnReg.IsEnabled = false;
                txtUser.Clear();
                txtPass.Clear();
                msFile.IsEnabled = true;
                msLoginExit.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Invalid Login");
                txtUser.Clear();
                txtPass.Clear();
            }
            d.CloseCon();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.Show();
        }
    }
}
