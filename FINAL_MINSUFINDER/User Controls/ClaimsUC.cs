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
            UserDatabaseHelper.LoadClaims(dgvClaims);
        }

        private void ClaimsUC_Load(object sender, EventArgs e)
        {
            LoadClaims();
        }

        private void dgvClaims_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (dgvClaims.DataSource is DataTable dt)
            {
                string searchValue = txtSearch.Text.Trim().Replace("'", "''");

                if (string.IsNullOrEmpty(searchValue))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Pinalitan natin ng tamang column names na meron sa Claims table
                    dt.DefaultView.RowFilter = string.Format(
                        "ItemName LIKE '%{0}%' OR OwnerFullName LIKE '%{0}%' OR FinderFullName LIKE '%{0}%' OR ClaimantFullName LIKE '%{0}%'", searchValue);
                }
            }
        }
    }
}