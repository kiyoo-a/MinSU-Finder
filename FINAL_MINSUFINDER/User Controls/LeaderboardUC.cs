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
            LoadLeaderboardData();
        }

        private void LoadLeaderboardData()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY (COUNT(*) * 10) DESC) AS [Rank],
                            Founder AS [Student Name],
                            COUNT(*) AS [Items Reported],
                            (COUNT(*) * 10) AS [Total Points]
                        FROM FoundItems
                        WHERE Founder IS NOT NULL AND Founder <> ''
                        GROUP BY Founder
                        ORDER BY [Total Points] DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // 1. I-load ang buong listahan sa DataGridView
                        dgvLeaderboard.DataSource = dt;

                        // 2. I-load ang #1 student sa Top Finder Card gamit ang bagong label names
                        if (dt.Rows.Count > 0)
                        {
                            lblTop.Text = dt.Rows[0]["Student Name"].ToString();
                            lblTopFound.Text = dt.Rows[0]["Items Reported"].ToString() + " Found Items";
                        }
                        else
                        {
                            lblTop.Text = "Wala pang top finder";
                            lblTopFound.Text = "0 Found Items";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading leaderboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}