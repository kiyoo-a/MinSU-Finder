using FINAL_MINSUFINDER.User_Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace FINAL_MINSUFINDER
{
    public partial class Dashboard : Form
    {
        private readonly Control[] dashboardControls;
        private readonly List<DataGridViewRow> rowsToPrint = new List<DataGridViewRow>();
        private int printRowIndex = 0;
        private DateTime reportStartDate;
        private DateTime reportEndDate;
        private string topCommonLocation = "N/A";

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
            FilterDashboardActivities();
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

        private void FilterDashboardActivities()
        {
            if (!(dgvRecentActivities.DataSource is DataTable dt))
            {
                return;
            }

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);

            if (endDate < startDate)
            {
                dt.DefaultView.RowFilter = "1 = 0";
                return;
            }

            dt.DefaultView.RowFilter = string.Format(
                CultureInfo.InvariantCulture,
                "ActivityDate >= #{0:MM/dd/yyyy HH:mm:ss}# AND ActivityDate <= #{1:MM/dd/yyyy HH:mm:ss}#",
                startDate,
                endDate
            );
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
            Hide();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            FilterDashboardActivities();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            FilterDashboardActivities();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            reportStartDate = dtpStartDate.Value.Date;
            reportEndDate = dtpEndDate.Value.Date;

            if (reportEndDate < reportStartDate)
            {
                MessageBox.Show(
                    "End date cannot be earlier than start date.",
                    "Invalid Date Range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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

            topCommonLocation = UserDatabaseHelper.GetMostCommonLocation(reportStartDate, reportEndDate);
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
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (Font titleFont = new Font("Segoe UI", 17, FontStyle.Bold))
            using (Font subFont = new Font("Segoe UI", 9.5f, FontStyle.Regular))
            using (Font metaLabelFont = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (Font metaValFont = new Font("Segoe UI", 9.5f, FontStyle.Regular))
            using (Font headerFont = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (Font bodyFont = new Font("Segoe UI", 9f, FontStyle.Regular))
            using (Font badgeFont = new Font("Segoe UI", 8.5f, FontStyle.Bold))
            using (SolidBrush darkGreen = new SolidBrush(Color.FromArgb(27, 94, 32)))
            using (SolidBrush accentGreen = new SolidBrush(Color.FromArgb(46, 125, 50)))
            using (SolidBrush bannerBg = new SolidBrush(Color.FromArgb(244, 248, 244)))
            using (SolidBrush headerBg = new SolidBrush(Color.FromArgb(27, 94, 32)))
            using (SolidBrush zebraBg = new SolidBrush(Color.FromArgb(249, 251, 249)))
            using (SolidBrush bodyTextBrush = new SolidBrush(Color.FromArgb(35, 35, 35)))
            using (Pen bannerBorder = new Pen(Color.FromArgb(200, 220, 200), 1))
            using (Pen gridPen = new Pen(Color.FromArgb(224, 228, 224), 1))
            {
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int width = e.MarginBounds.Width;

                g.FillRectangle(accentGreen, x, y + 3, 5, 24);
                g.DrawString("MinSU Finder — Activity Report", titleFont, darkGreen, x + 14, y);
                y += 32;

                g.DrawString(
                    $"Period: {reportStartDate:MMMM dd, yyyy} – {reportEndDate:MMMM dd, yyyy}   •   Generated: {DateTime.Now:MMM dd, yyyy hh:mm tt}",
                    subFont,
                    Brushes.DimGray,
                    x,
                    y
                );
                y += 24;

                int cardHeight = 32;
                Rectangle cardRect = new Rectangle(x, y, width, cardHeight);
                g.FillRectangle(bannerBg, cardRect);
                g.DrawRectangle(bannerBorder, cardRect);

                string labelText = "Most Common Lost / Found Place:";
                g.DrawString(labelText, metaLabelFont, darkGreen, x + 10, y + 8);

                SizeF labelSize = g.MeasureString(labelText, metaLabelFont);
                g.DrawString(topCommonLocation, metaValFont, Brushes.Black, x + 12 + labelSize.Width, y + 8);
                y += cardHeight + 14;

                int[] colWidths =
                {
                    (int)(width * 0.16),
                    (int)(width * 0.38),
                    (int)(width * 0.25),
                    (int)(width * 0.21)
                };

                string[] headers = { "Activity Type", "Description", "User", "Date & Time" };
                int headerHeight = 28;
                int rowHeight = 26;

                int currX = x;
                for (int i = 0; i < headers.Length; i++)
                {
                    Rectangle rect = new Rectangle(currX, y, colWidths[i], headerHeight);
                    g.FillRectangle(headerBg, rect);
                    g.DrawString(
                        headers[i],
                        headerFont,
                        Brushes.White,
                        new RectangleF(currX + 6, y + 6, colWidths[i] - 12, headerHeight - 8)
                    );
                    currX += colWidths[i];
                }
                y += headerHeight;

                int footerReserve = 28;

                while (printRowIndex < rowsToPrint.Count)
                {
                    DataGridViewRow row = rowsToPrint[printRowIndex];

                    if (y + rowHeight > e.MarginBounds.Bottom - footerReserve)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    bool isEven = printRowIndex % 2 == 1;
                    currX = x;

                    for (int c = 0; c < Math.Min(4, row.Cells.Count); c++)
                    {
                        object rawVal = row.Cells[c].Value;
                        string val;

                        if (c == 3 && rawVal is DateTime dt)
                        {
                            val = dt.ToString("MM/dd/yyyy hh:mm tt");
                        }
                        else if (c == 3 && DateTime.TryParse(Convert.ToString(rawVal), out DateTime parsedDt))
                        {
                            val = parsedDt.ToString("MM/dd/yyyy hh:mm tt");
                        }
                        else
                        {
                            val = Convert.ToString(rawVal) ?? string.Empty;
                        }

                        Rectangle rect = new Rectangle(currX, y, colWidths[c], rowHeight);
                        if (isEven)
                        {
                            g.FillRectangle(zebraBg, rect);
                        }

                        g.DrawRectangle(gridPen, rect);

                        Font cellFont = (c == 0) ? badgeFont : bodyFont;
                        Brush cellBrush = (c == 0) ? (Brush)darkGreen : bodyTextBrush;

                        g.DrawString(
                            val,
                            cellFont,
                            cellBrush,
                            new RectangleF(currX + 6, y + 5, colWidths[c] - 12, rowHeight - 6)
                        );

                        currX += colWidths[c];
                    }

                    y += rowHeight;
                    printRowIndex++;
                }

                int footerY = e.MarginBounds.Bottom - 20;
                g.DrawLine(gridPen, x, footerY - 6, x + width, footerY - 6);
                g.DrawString($"Total Activities: {rowsToPrint.Count}", metaLabelFont, Brushes.DimGray, x, footerY);
                g.DrawString(
                    "MinSU Finder",
                    subFont,
                    Brushes.DimGray,
                    x + width - g.MeasureString("MinSU Finder", subFont).Width,
                    footerY
                );

                e.HasMorePages = false;
            }
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblUserCount_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}