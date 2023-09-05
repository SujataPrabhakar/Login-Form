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
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }

        private void FrmSignUp_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-77PFC770;Initial Catalog=LoginUsers;Integrated Security=True";
            con.Open();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = "Data Source=LAPTOP-77PFC770;Initial Catalog=LoginUsers;Integrated Security=True";
                    connection.Open();

                    string command = $"insert into LoginItems (UserName,UserPassword) values(@userName, @userPassword)";
                    
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.Parameters.AddWithValue("@userName", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@userPassword", txtPassword.Text);

                    int rowAffected = cmd.ExecuteNonQuery();
                    if(rowAffected>0)
                    {
                        MessageBox.Show("Your Data added to the system");
                        txtUserName.Text = " ";
                        txtPassword.Text = " ";
                        txtConfirmPassword.Text = " ";
                    }
                    else
                    {
                        MessageBox.Show("Your Data not Added successfully. Please try again.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Password and Confirm Password are not same!");
            }


        }

       
    }
}
