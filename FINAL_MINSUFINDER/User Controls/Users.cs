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

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
