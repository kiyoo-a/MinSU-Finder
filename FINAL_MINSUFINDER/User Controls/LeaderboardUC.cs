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
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string dateCondition = "";
                    string timeLabelText = "of the Month"; 

                    filterType = filterType?.Trim();

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
                    else 
                    {
                        dateCondition = "";
                        timeLabelText = "of All Time";
                    }
                    lblFinderTitle.Text = timeLabelText;

                    string query = $@" SELECT ROW_NUMBER() OVER (ORDER BY COUNT(*) DESC) AS [Rank], 
                                    LTRIM(RTRIM(Founder)) AS [Student Name], COUNT(*) AS [Items Reported],
                                    (COUNT(*) * 10) AS [Total Points] FROM FoundItems {dateCondition}
                                    GROUP BY LTRIM(RTRIM(Founder))HAVING LTRIM(RTRIM(Founder)) IS NOT NULL AND
                                    LTRIM(RTRIM(Founder)) <> '' ORDER BY [Items Reported] DESC";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvLeaderboard.DataSource = dt;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading leaderboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cmbCategory.Text;
            LoadLeaderboard(selectedFilter);
        }
    }
}