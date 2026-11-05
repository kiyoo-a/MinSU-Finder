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
                string query = @"SELECT IdNumber, FullName, UserName, Course, Password
                         FROM UsersAccount";

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
    }
}
