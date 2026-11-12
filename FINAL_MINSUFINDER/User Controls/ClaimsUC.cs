using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;



namespace FINAL_MINSUFINDER.User_Controls
{
    public partial class ClaimsUC : UserControl
    {
        public ClaimsUC()
        {
            InitializeComponent();
        }

        public void LoadClaims()
        {
            DatabaseConnection db = new DatabaseConnection();
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Claims";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvClaims.DataSource = dt;
                }
            }
        }
        private void ClaimsUC_Load(object sender, EventArgs e)
        {
            LoadClaims();
        }
    }
}
