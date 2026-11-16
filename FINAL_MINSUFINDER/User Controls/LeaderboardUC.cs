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
    public partial class LeaderboardUC : UserControl
    {
        public LeaderboardUC()
        {
            InitializeComponent();
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedItem = "This Month";
                if (cmbCategory.SelectedIndex == -1)
                {
                    cmbCategory.SelectedIndex = 0;
                }
            }
            else
            {
                LoadLeaderboard("This Month");
            }
        }

        private void LoadLeaderboard(string filterType)
        {
            DataTable dt = UserDatabaseHelper.GetLeaderboard(filterType, out string timeLabel);
            lblFinderTitle.Text = timeLabel;

            if (dt != null)
            {
                dgvLeaderboard.DataSource = dt;
                dgvLeaderboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dt.Rows.Count > 0)
                {
                    lblTopName.Text = dt.Rows[0]["Student Name"].ToString();
                    lblTopFound.Text = dt.Rows[0]["Items Reported"].ToString() + " Found Items";
                }
                else
                {
                    lblTopName.Text = " ";
                    lblTopFound.Text = "0 Found Items";
                }
            }
        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cmbCategory.Text;
            LoadLeaderboard(selectedFilter);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}