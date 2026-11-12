using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_MINSUFINDER
{
    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();

                string query = @"INSERT INTO UsersAccount
            (IdNumber, FullName, UserName, Course, Password)
            VALUES
            (@IdNumber, @FullName, @UserName, @Course, @Password)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdNumber", txtID.Text);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@UserName", txtUserNamereg.Text);
                    cmd.Parameters.AddWithValue("@Course", txtCoursereg.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPasswordreg.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registration Successful!");

                    txtID.Clear();
                    txtFullName.Clear();
                    txtUserNamereg.Clear();
                    txtCoursereg.Clear();
                    txtPasswordreg.Clear();
                }
            }
            this.Hide();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
