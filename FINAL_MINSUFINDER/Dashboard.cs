using FINAL_MINSUFINDER.User_Controls;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace FINAL_MINSUFINDER
{
    public partial class Dashboard : Form
    {
        private Control[] dashboardControls;
        public Dashboard()
        {
            InitializeComponent();
            dashboardControls = pnlContent.Controls
            .Cast<Control>()
            .ToArray();
        }
        private void LoadUserControl(UserControl uc)
        {
            pnlContent.Controls.Clear();

            uc.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(uc);

            uc.BringToFront();
        }
        private void HighlightButton(Button activeBtn)
        {
            
            btnDashboard.BackColor = Color.White;
            btnLostItems.BackColor = Color.White;
            btnFoundItems.BackColor = Color.White;
            btnClaims.BackColor = Color.White;
            btnLeaderboard.BackColor = Color.White;
            btnUsers.BackColor = Color.White;

           
            activeBtn.BackColor = Color.LightGreen;
        }


        private void LoadDashboardCounts()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"
                SELECT
                    (SELECT COUNT(*) FROM FoundItems) AS FoundCount,
                    (SELECT COUNT(*) FROM LostItems WHERE Status = 'Lost') AS LostCount,
                    (SELECT COUNT(*) FROM Claims) AS ClaimCount,
                    (SELECT COUNT(*) FROM UsersAccount) AS UserCount";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblFoundCount.Text = reader["FoundCount"].ToString();
                            lblLostCount.Text = reader["LostCount"].ToString();
                            lblClaimCount.Text = reader["ClaimCount"].ToString();
                            lblUserCount.Text = reader["UserCount"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard counts: " + ex.Message);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
            LoadRecentActivities();

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboardCounts();
            HighlightButton(btnDashboard);
            pnlContent.Controls.Clear();

            foreach (Control control in dashboardControls)
            {
                pnlContent.Controls.Add(control);
            }
        }

        private void btnLostItems_Click(object sender, EventArgs e)
        {
            HighlightButton(btnLostItems);
            LoadUserControl(new LostItemsUC());
        }

        private void btnFoundItems_Click(object sender, EventArgs e)
        {
            HighlightButton(btnFoundItems);
            LoadUserControl(new FoundItemsUC());
        }

        private void btnClaims_Click(object sender, EventArgs e)
        {
            HighlightButton(btnClaims);
            LoadUserControl(new ClaimsUC());
        }



        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            HighlightButton(btnLeaderboard);
            LoadUserControl(new LeaderboardUC());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            HighlightButton(btnUsers);
            LoadUserControl(new Users());
        }

        private void LoadRecentActivities()
        {
            
    try
    {
        DatabaseConnection db = new DatabaseConnection();

        using (SqlConnection con = db.GetConnection())
        {
            con.Open();

            string query = @"
                SELECT TOP 20 *
                FROM
                (
                    SELECT
                        'Registration' AS ActivityType,
                        'New student registered' AS Description,
                        FullName AS ActivityUser,
                        DateRegistered AS ActivityDate
                    FROM UsersAccount

                    UNION ALL

                    SELECT
                        'Lost Item',
                        CONCAT('Reported a lost item: ', ItemName),
                        ItemOwner,
                        DateLost
                    FROM LostItems

                    UNION ALL

                    SELECT
                        'Found Item',
                        CONCAT('Reported a found item: ', ItemName),
                        Founder,
                        DateFound
                    FROM FoundItems

                    UNION ALL

                    SELECT
                        'Claim',
                        CONCAT('Claimed an item: ', ItemName),
                        ClaimantFullName,
                        DateClaimed
                    FROM Claims

                ) AS Activities

                ORDER BY ActivityDate DESC";

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvRecentActivities.DataSource = dt;
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error loading recent activities: " + ex.Message);
    }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadRecentActivities();
        }
    }
}
