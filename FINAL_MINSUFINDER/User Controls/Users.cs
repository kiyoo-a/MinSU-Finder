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

namespace FINAL_MINSUFINDER.User_Controls
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            DatabaseConnection db = new DatabaseConnection();

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();

                string query = "SELECT * FROM UsersAccount";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvUsers.DataSource = dt;
                }
            }

        }

        private void Users_Load(object sender, EventArgs e)
        {

            LoadUsers();

            txtID.Clear();
            txtFullName.Clear();
            txtUsername.Clear();
            txtCourse.Clear();
            txtPassword.Clear();

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                // Palitan ang "idColumn" ng eksaktong Name property ng column sa iyong DataGridView Designer

                txtID.Text = row.Cells["idNumber"].Value?.ToString();

                txtFullName.Text = row.Cells["FullName"].Value?.ToString();
                txtUsername.Text = row.Cells["UserName"].Value?.ToString();
                txtCourse.Text = row.Cells["Course"].Value?.ToString();
                txtPassword.Text = row.Cells["Password"].Value?.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            txtID.Clear();
            txtFullName.Clear();
            txtUsername.Clear();
            txtCourse.Clear();
            txtPassword.Clear();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseConnection db = new DatabaseConnection();

                    using (SqlConnection con = db.GetConnection())
                    {
                        con.Open();

                        string query = "DELETE FROM UsersAccount WHERE IdNumber = @IdNumber";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@IdNumber", txtID.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User successfully deleted!");

                                LoadUsers();

                                txtID.Clear();
                                txtFullName.Clear();
                                txtUsername.Clear();
                                txtCourse.Clear();
                                txtPassword.Clear();
                            }
                            else
                            {
                                MessageBox.Show("User not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            DatabaseConnection db = new DatabaseConnection();

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();

                string query = @"UPDATE UsersAccount
                         SET FullName = @FullName,
                             UserName = @UserName,
                             Course = @Course,
                             Password = @Password
                         WHERE IdNumber = @IdNumber";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdNumber", txtID.Text);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("User updated successfully!");

                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("No user was updated.");
                    }
                }
            }
        }
    }
}
