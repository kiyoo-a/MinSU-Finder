using FINAL_MINSUFINDER.User_Controls;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FINAL_MINSUFINDER
{
    public partial class Dashboard : Form
    {
        private Control[] dashboardControls;

        public Dashboard()
        {
            InitializeComponent();
            dashboardControls = pnlContent.Controls.Cast<Control>().ToArray();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
            LoadRecentActivities();
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
            DataRow counts = UserDatabaseHelper.GetDashboardCounts();
            if (counts != null)
            {
                lblFoundCount.Text = counts["FoundCount"].ToString();
                lblLostCount.Text = counts["LostCount"].ToString();
                lblClaimCount.Text = counts["ClaimCount"].ToString();
                lblUserCount.Text = counts["UserCount"].ToString();
            }
        }

        private void LoadRecentActivities()
        {
            UserDatabaseHelper.LoadRecentActivities(dgvRecentActivities);
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

        private void btnUsers_Click(object sender, EventArgs e)
        {
            HighlightButton(btnUsers);
            LoadUserControl(new Users());
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadRecentActivities();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }
    }
}