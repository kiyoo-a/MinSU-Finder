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

     

        private void Users_Load(object sender, EventArgs e)
        {


        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
            
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
