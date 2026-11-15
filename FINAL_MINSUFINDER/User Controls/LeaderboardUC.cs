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
                            lblTopName.Text = dt.Rows[0]["Student Name"].ToString();
                            lblTopFound.Text = dt.Rows[0]["Items Reported"].ToString() + " Found Items";
                        }
                        else
                        {
                            lblTopName.Text = "Wala pang top finder";
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
        private void LoadLeaderboard(string filterType)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string dateCondition = "";
                    string timeLabelText = "of the Month"; // Default

                    // Linisin ang filterType para maiwasan ang isyu sa spacing o capitalization
                    filterType = filterType?.Trim();

                    // Pagpapalit ng label at condition batay sa eksaktong pinili sa ComboBox
                    if (filterType == "Today")
                    {
                        dateCondition = "WHERE CAST(DateFound AS DATE) = CAST(GETDATE() AS DATE)";
                        timeLabelText = "of this Day";
                    }
                    else if (filterType == "This Week" || filterType == "this Week")
                    {
                        dateCondition = "WHERE DateFound >= DATEADD(day, -7, GETDATE())";
                        timeLabelText = "of this Week";
                    }
                    else if (filterType == "This Month" || filterType == "this Month")
                    {
                        dateCondition = "WHERE MONTH(DateFound) = MONTH(GETDATE()) AND YEAR(DateFound) = YEAR(GETDATE())";
                        timeLabelText = "of this Month";
                    }
                    else // All Time
                    {
                        dateCondition = "";
                        timeLabelText = "of All Time";
                    }

                    // Awtomatikong magpapalit ang text ng label sa gilid ng tropeo
                    lblFinderTitle.Text = timeLabelText;

                    string query = $@"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY COUNT(*) DESC) AS Rank,
                    Founder AS Student_Name,
                    COUNT(*) AS ItemsReported,
                    (COUNT(*) * 10) AS TotalPoints
                FROM FoundItems
                {dateCondition}
                GROUP BY Founder
                ORDER BY ItemsReported DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvLeaderboard.DataSource = dt;

                        // Ilagay ang pangalan at total ng Top 1 sa card
                        if (dt.Rows.Count > 0)
                        {
                            lblTopName.Text = dt.Rows[0]["Student_Name"].ToString();
                            lblTopFound.Text = dt.Rows[0]["ItemsReported"].ToString() + " Found Items";
                        }
                        else
                        {
                            lblTopName.Text = "No records";
                            lblTopFound.Text = "0 Found Items";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading leaderboard: " + ex.Message);
            }
        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cmbCategory.Text;
            LoadLeaderboard(selectedFilter);
        }
        private void LeaderboardUC_Load(object sender, EventArgs e)
        {
            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0; // Automatic na pipiliin ang "This Month" sa simula
            }
            else
            {
                LoadLeaderboard("This Month");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}