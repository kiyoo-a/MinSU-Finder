namespace FINAL_MINSUFINDER
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.Charts.WinForms.GunaDoughnutDataset gunaDoughnutDataset2;
            Guna.Charts.WinForms.LPoint lPoint22 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint23 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint24 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint25 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint26 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint27 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint28 = new Guna.Charts.WinForms.LPoint();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnLostItems = new System.Windows.Forms.Button();
            this.btnFoundItems = new System.Windows.Forms.Button();
            this.btnLeaderboard = new System.Windows.Forms.Button();
            this.btnClaims = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.gunaDoughnutDataset1 = new Guna.Charts.WinForms.GunaDoughnutDataset();
            this.gunaAreaDataset1 = new Guna.Charts.WinForms.GunaAreaDataset();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.lblClaimCount = new System.Windows.Forms.Label();
            this.lblLostCount = new System.Windows.Forms.Label();
            this.lblFoundCount = new System.Windows.Forms.Label();
            this.dgvRecentActivities = new System.Windows.Forms.DataGridView();
            this.lblTopFinder = new System.Windows.Forms.Label();
            this.lblTopFinderCount = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            gunaDoughnutDataset2 = new Guna.Charts.WinForms.GunaDoughnutDataset();
            this.guna2GradientPanel1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivities)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaDoughnutDataset2
            // 
            lPoint22.Label = "2342";
            lPoint22.Y = 0D;
            lPoint23.Label = "324";
            lPoint23.Y = 0D;
            gunaDoughnutDataset2.DataPoints.AddRange(new Guna.Charts.WinForms.LPoint[] {
            lPoint22,
            lPoint23});
            gunaDoughnutDataset2.FillColors.AddRange(new System.Drawing.Color[] {
            System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))),
            System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))),
            System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))});
            gunaDoughnutDataset2.Label = "Doughnut2";
            // 
            // btnDashboard
            // 
            this.btnDashboard.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnDashboard.Location = new System.Drawing.Point(28, 228);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(156, 39);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnLostItems
            // 
            this.btnLostItems.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLostItems.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnLostItems.Location = new System.Drawing.Point(28, 283);
            this.btnLostItems.Name = "btnLostItems";
            this.btnLostItems.Size = new System.Drawing.Size(156, 39);
            this.btnLostItems.TabIndex = 2;
            this.btnLostItems.Text = "Lost Items";
            this.btnLostItems.UseVisualStyleBackColor = true;
            this.btnLostItems.Click += new System.EventHandler(this.btnLostItems_Click);
            // 
            // btnFoundItems
            // 
            this.btnFoundItems.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoundItems.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnFoundItems.Location = new System.Drawing.Point(28, 338);
            this.btnFoundItems.Name = "btnFoundItems";
            this.btnFoundItems.Size = new System.Drawing.Size(156, 39);
            this.btnFoundItems.TabIndex = 3;
            this.btnFoundItems.Text = "Found Items";
            this.btnFoundItems.UseVisualStyleBackColor = true;
            this.btnFoundItems.Click += new System.EventHandler(this.btnFoundItems_Click);
            // 
            // btnLeaderboard
            // 
            this.btnLeaderboard.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaderboard.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnLeaderboard.Location = new System.Drawing.Point(28, 445);
            this.btnLeaderboard.Name = "btnLeaderboard";
            this.btnLeaderboard.Size = new System.Drawing.Size(156, 39);
            this.btnLeaderboard.TabIndex = 5;
            this.btnLeaderboard.Text = "Leaderboard";
            this.btnLeaderboard.UseVisualStyleBackColor = true;
            this.btnLeaderboard.Click += new System.EventHandler(this.btnLeaderboard_Click);
            // 
            // btnClaims
            // 
            this.btnClaims.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClaims.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnClaims.Location = new System.Drawing.Point(28, 393);
            this.btnClaims.Name = "btnClaims";
            this.btnClaims.Size = new System.Drawing.Size(156, 39);
            this.btnClaims.TabIndex = 7;
            this.btnClaims.Text = "Claims";
            this.btnClaims.UseVisualStyleBackColor = true;
            this.btnClaims.Click += new System.EventHandler(this.btnClaims_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSize = true;
            this.btnLogout.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnLogout.Location = new System.Drawing.Point(28, 627);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(156, 39);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // gunaDoughnutDataset1
            // 
            this.gunaDoughnutDataset1.BorderColors.AddRange(new System.Drawing.Color[] {
            System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))),
            System.Drawing.Color.Lime,
            System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))),
            System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))),
            System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(33)))))});
            lPoint24.Y = 0D;
            lPoint25.Label = "32";
            lPoint25.Y = 0D;
            lPoint26.Label = "323";
            lPoint26.Y = 0D;
            lPoint27.Label = "3425";
            lPoint27.Y = 0D;
            lPoint28.Y = 0D;
            this.gunaDoughnutDataset1.DataPoints.AddRange(new Guna.Charts.WinForms.LPoint[] {
            lPoint24,
            lPoint25,
            lPoint26,
            lPoint27,
            lPoint28});
            this.gunaDoughnutDataset1.FillColors.AddRange(new System.Drawing.Color[] {
            System.Drawing.Color.Empty,
            System.Drawing.Color.Empty,
            System.Drawing.Color.Empty,
            System.Drawing.Color.Empty});
            this.gunaDoughnutDataset1.Label = "Doughnut1";
            // 
            // gunaAreaDataset1
            // 
            this.gunaAreaDataset1.BorderColor = System.Drawing.Color.Empty;
            this.gunaAreaDataset1.FillColor = System.Drawing.Color.Empty;
            this.gunaAreaDataset1.Label = "Area1";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.guna2Panel1);
            this.guna2GradientPanel1.Controls.Add(this.btnDashboard);
            this.guna2GradientPanel1.Controls.Add(this.btnLogout);
            this.guna2GradientPanel1.Controls.Add(this.btnLostItems);
            this.guna2GradientPanel1.Controls.Add(this.btnClaims);
            this.guna2GradientPanel1.Controls.Add(this.btnFoundItems);
            this.guna2GradientPanel1.Controls.Add(this.btnLeaderboard);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(214, 701);
            this.guna2GradientPanel1.TabIndex = 22;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel1.BackgroundImage")));
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Location = new System.Drawing.Point(20, 7);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(164, 206);
            this.guna2Panel1.TabIndex = 25;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlContent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlContent.BackgroundImage")));
            this.pnlContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlContent.Controls.Add(this.label3);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Controls.Add(this.dtpStartDate);
            this.pnlContent.Controls.Add(this.dtpEndDate);
            this.pnlContent.Controls.Add(this.btnGenerateReport);
            this.pnlContent.Controls.Add(this.lblTopFinderCount);
            this.pnlContent.Controls.Add(this.lblTopFinder);
            this.pnlContent.Controls.Add(this.btnReload);
            this.pnlContent.Controls.Add(this.lblClaimCount);
            this.pnlContent.Controls.Add(this.lblLostCount);
            this.pnlContent.Controls.Add(this.lblFoundCount);
            this.pnlContent.Controls.Add(this.dgvRecentActivities);
            this.pnlContent.Location = new System.Drawing.Point(217, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1038, 702);
            this.pnlContent.TabIndex = 6;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(91)))), ((int)(((byte)(51)))));
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(906, 668);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(98, 31);
            this.btnReload.TabIndex = 49;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblClaimCount
            // 
            this.lblClaimCount.BackColor = System.Drawing.Color.Transparent;
            this.lblClaimCount.Font = new System.Drawing.Font("Segoe UI Semibold", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaimCount.Location = new System.Drawing.Point(616, 139);
            this.lblClaimCount.Name = "lblClaimCount";
            this.lblClaimCount.Size = new System.Drawing.Size(132, 60);
            this.lblClaimCount.TabIndex = 6;
            this.lblClaimCount.Text = "(678)";
            this.lblClaimCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLostCount
            // 
            this.lblLostCount.BackColor = System.Drawing.Color.Transparent;
            this.lblLostCount.Font = new System.Drawing.Font("Segoe UI Semibold", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLostCount.Location = new System.Drawing.Point(374, 139);
            this.lblLostCount.Name = "lblLostCount";
            this.lblLostCount.Size = new System.Drawing.Size(133, 60);
            this.lblLostCount.TabIndex = 7;
            this.lblLostCount.Text = "(345)";
            this.lblLostCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFoundCount
            // 
            this.lblFoundCount.BackColor = System.Drawing.Color.Transparent;
            this.lblFoundCount.Font = new System.Drawing.Font("Segoe UI Semibold", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoundCount.Location = new System.Drawing.Point(130, 139);
            this.lblFoundCount.Name = "lblFoundCount";
            this.lblFoundCount.Size = new System.Drawing.Size(134, 60);
            this.lblFoundCount.TabIndex = 8;
            this.lblFoundCount.Text = "(012)";
            this.lblFoundCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvRecentActivities
            // 
            this.dgvRecentActivities.AllowUserToAddRows = false;
            this.dgvRecentActivities.AllowUserToDeleteRows = false;
            this.dgvRecentActivities.AllowUserToOrderColumns = true;
            this.dgvRecentActivities.AllowUserToResizeColumns = false;
            this.dgvRecentActivities.AllowUserToResizeRows = false;
            this.dgvRecentActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentActivities.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentActivities.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvRecentActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentActivities.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecentActivities.GridColor = System.Drawing.Color.White;
            this.dgvRecentActivities.Location = new System.Drawing.Point(38, 283);
            this.dgvRecentActivities.Name = "dgvRecentActivities";
            this.dgvRecentActivities.RowHeadersVisible = false;
            this.dgvRecentActivities.RowHeadersWidth = 51;
            this.dgvRecentActivities.RowTemplate.Height = 24;
            this.dgvRecentActivities.Size = new System.Drawing.Size(966, 383);
            this.dgvRecentActivities.TabIndex = 20;
            // 
            // lblTopFinder
            // 
            this.lblTopFinder.BackColor = System.Drawing.Color.Transparent;
            this.lblTopFinder.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopFinder.Location = new System.Drawing.Point(827, 148);
            this.lblTopFinder.Name = "lblTopFinder";
            this.lblTopFinder.Size = new System.Drawing.Size(155, 20);
            this.lblTopFinder.TabIndex = 50;
            this.lblTopFinder.Text = "Mark Clarence Jimenez";
            this.lblTopFinder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTopFinderCount
            // 
            this.lblTopFinderCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTopFinderCount.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopFinderCount.Location = new System.Drawing.Point(849, 168);
            this.lblTopFinderCount.Name = "lblTopFinderCount";
            this.lblTopFinderCount.Size = new System.Drawing.Size(112, 16);
            this.lblTopFinderCount.TabIndex = 51;
            this.lblTopFinderCount.Text = "3 Items Reported";
            this.lblTopFinderCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(91)))), ((int)(((byte)(51)))));
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(798, 667);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(105, 31);
            this.btnGenerateReport.TabIndex = 52;
            this.btnGenerateReport.Text = "Print";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(964, 252);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(20, 22);
            this.dtpEndDate.TabIndex = 53;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(910, 252);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(20, 22);
            this.dtpStartDate.TabIndex = 54;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(866, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "From:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(936, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 57;
            this.label3.Text = "To:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 701);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.pnlContent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MinSU Finder: Lost and Found Management System";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnLostItems;
        private System.Windows.Forms.Button btnFoundItems;
        private System.Windows.Forms.Button btnLeaderboard;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnClaims;
        private System.Windows.Forms.Label lblLostCount;
        private System.Windows.Forms.Label lblFoundCount;
        private System.Windows.Forms.Label lblClaimCount;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvRecentActivities;
        private Guna.Charts.WinForms.GunaDoughnutDataset gunaDoughnutDataset1;
        private Guna.Charts.WinForms.GunaAreaDataset gunaAreaDataset1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblTopFinder;
        private System.Windows.Forms.Label lblTopFinderCount;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}