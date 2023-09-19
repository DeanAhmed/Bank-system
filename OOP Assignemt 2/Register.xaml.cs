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
using System.Windows.Shapes;
using DAL;
using BIZ;
using System.Data;
using System.Data.SqlClient;

namespace OOP_Assignemt_2
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        DAO d = new DAO();
        Hash h = new Hash();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUser.Text;
            string pass = h.HashData(txtPass.Password);

            SqlCommand cmd = d.OpenCon().CreateCommand();
            cmd.CommandText = "uspRegister";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            cmd.ExecuteNonQuery();
            d.CloseCon();

            txtUser.Clear();
            txtPass.Clear();
        }
    }
}
