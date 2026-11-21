using FINAL_MINSUFINDER.User_Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace FINAL_MINSUFINDER
{
    public partial class Dashboard : Form
    {
        private Control[] dashboardControls;
        private readonly List<DataGridViewRow> rowsToPrint = new List<DataGridViewRow>();
        private int printRowIndex = 0;
        private DateTime reportStartDate;
        private DateTime reportEndDate;


        public Dashboard()
        {
            InitializeComponent();
            dashboardControls = pnlContent.Controls.Cast<Control>().ToArray();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {


            LoadDashboardCounts();
            LoadRecentActivities();
            LoadTopFinder();
            DateTime now = DateTime.Today;
            dtpStartDate.Value = new DateTime(now.Year, now.Month, 1);
            dtpEndDate.Value = now;
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

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUserCount_Click(object sender, EventArgs e)
        {

        }

        private void LoadTopFinder()
        {
            DataTable dt = UserDatabaseHelper.GetTopFinder();

            if (dt != null && dt.Rows.Count > 0)
            {
                lblTopFinder.Text = dt.Rows[0]["FullName"].ToString();
                lblTopFinderCount.Text = dt.Rows[0]["ItemsReported"].ToString() + " item(s) reported";
            }
            else
            {
                lblTopFinder.Text = "No Top Finder Yet";
                lblTopFinderCount.Text = "0 item(S) reported";
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            reportStartDate = dtpStartDate.Value.Date;
            reportEndDate = dtpEndDate.Value.Date;

            if (reportEndDate < reportStartDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date Range",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rowsToPrint.Clear();

            foreach (DataGridViewRow row in dgvRecentActivities.Rows)
            {
                if (!row.IsNewRow)
                {
                    rowsToPrint.Add(row);
                }
            }

            if (rowsToPrint.Count == 0)
            {
                MessageBox.Show("No activities found for the selected date range.");
                return;
            }

            printRowIndex = 0;

            PrintDocument printDoc = new PrintDocument
            {
                DocumentName = $"MinSU Finder Report ({reportStartDate:yyyy-MM-dd} to {reportEndDate:yyyy-MM-dd})"
            };
            printDoc.PrintPage += PrintDoc_PrintPage;

            using (PrintPreviewDialog preview = new PrintPreviewDialog())
            {
                preview.Document = printDoc;
                preview.WindowState = FormWindowState.Maximized;
                preview.ShowDialog();
            }
        }
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font subFont = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            Font headerFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            Font bodyFont = new Font("Segoe UI", 9f, FontStyle.Regular);

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int width = e.MarginBounds.Width;

            g.DrawString("MinSU Finder - Activity Report", titleFont, Brushes.DarkGreen, x, y);
            y += 28;
            g.DrawString($"Period: {reportStartDate:MMMM dd, yyyy} - {reportEndDate:MMMM dd, yyyy}   |   Generated: {DateTime.Now:MMM dd, yyyy}",
                subFont, Brushes.DimGray, x, y);
            y += 26;

            int[] colWidths = {
        (int)(width * 0.16),
        (int)(width * 0.38),
        (int)(width * 0.26),
        (int)(width * 0.20)
    };

            string[] headers = { "Activity Type", "Description", "User", "Date & Time" };
            int rowHeight = 26;

            int currX = x;
            for (int i = 0; i < headers.Length; i++)
            {
                Rectangle rect = new Rectangle(currX, y, colWidths[i], rowHeight);
                g.FillRectangle(Brushes.LightGray, rect);
                g.DrawRectangle(Pens.Gray, rect);
                g.DrawString(headers[i], headerFont, Brushes.Black, new RectangleF(currX + 4, y + 5, colWidths[i] - 8, rowHeight - 6));
                currX += colWidths[i];
            }
            y += rowHeight;

            while (printRowIndex < rowsToPrint.Count)
            {
                DataGridViewRow row = rowsToPrint[printRowIndex];

                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                currX = x;
                for (int c = 0; c < Math.Min(4, row.Cells.Count); c++)
                {
                    string val = Convert.ToString(row.Cells[c].Value) ?? string.Empty;
                    Rectangle rect = new Rectangle(currX, y, colWidths[c], rowHeight);
                    g.DrawRectangle(Pens.Silver, rect);
                    g.DrawString(val, bodyFont, Brushes.Black, new RectangleF(currX + 4, y + 5, colWidths[c] - 8, rowHeight - 6));
                    currX += colWidths[c];
                }

                y += rowHeight;
                printRowIndex++;
            }

            e.HasMorePages = false;
        }
        private void FilterDashboardActivities()
        {
            if (!(dgvRecentActivities.DataSource is DataTable dt))
                return;

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);

            if (endDate < startDate)
            {
                dt.DefaultView.RowFilter = "1 = 0"; // Show empty grid if invalid range
                return;
            }

            // Matches the ActivityDate column returned by LoadRecentActivities
            dt.DefaultView.RowFilter = string.Format(
                System.Globalization.CultureInfo.InvariantCulture,
                "ActivityDate >= #{0:MM/dd/yyyy HH:mm:ss}# AND ActivityDate <= #{1:MM/dd/yyyy HH:mm:ss}#",
                startDate,
                endDate
            );
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            FilterDashboardActivities();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            FilterDashboardActivities();
        }

    }

}