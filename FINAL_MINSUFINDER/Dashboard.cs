using FINAL_MINSUFINDER.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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




        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
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

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
