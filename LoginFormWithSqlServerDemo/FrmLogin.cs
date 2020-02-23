using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginFormWithSqlServerDemo
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-77PFC770;Initial Catalog=LoginUsers;Integrated Security=True";
            con.Open();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-77PFC770;Initial Catalog=LoginUsers;Integrated Security=True";
            con.Open();
            string command = "select UserName,UserPassword from LoginItems where UserName='" + txtUserName.Text + "'and UserPassword='" + txtPassword.Text + "'";
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            
            if(dataReader.HasRows)
            {
                MessageBox.Show("Login Success, Welcome to Homepage...");
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid Login, please check Username or Password");
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
            
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
