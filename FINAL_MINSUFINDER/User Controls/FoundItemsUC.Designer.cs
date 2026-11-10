namespace FINAL_MINSUFINDER.User_Controls
{
    partial class FoundItemsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoundItemsUC));
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtFoundDate = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtFounder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFoundLocation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFoundDescription = new System.Windows.Forms.TextBox();
            this.txtFoundName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvFoundItems = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoundItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 35);
            this.label4.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 172);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(951, 442);
            this.dataGridView1.TabIndex = 24;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Controls.Add(this.label1);
            this.guna2GradientPanel2.Controls.Add(this.cmbStatus);
            this.guna2GradientPanel2.Controls.Add(this.txtFoundDate);
            this.guna2GradientPanel2.Controls.Add(this.btnDelete);
            this.guna2GradientPanel2.Controls.Add(this.btnUpdate);
            this.guna2GradientPanel2.Controls.Add(this.btnAdd);
            this.guna2GradientPanel2.Controls.Add(this.txtFounder);
            this.guna2GradientPanel2.Controls.Add(this.label8);
            this.guna2GradientPanel2.Controls.Add(this.txtFoundLocation);
            this.guna2GradientPanel2.Controls.Add(this.label9);
            this.guna2GradientPanel2.Controls.Add(this.label10);
            this.guna2GradientPanel2.Controls.Add(this.txtFoundDescription);
            this.guna2GradientPanel2.Controls.Add(this.txtFoundName);
            this.guna2GradientPanel2.Controls.Add(this.label11);
            this.guna2GradientPanel2.Controls.Add(this.label12);
            this.guna2GradientPanel2.Controls.Add(this.label13);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(74)))), ((int)(((byte)(39)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(74)))), ((int)(((byte)(39)))));
            this.guna2GradientPanel2.Location = new System.Drawing.Point(694, 0);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(344, 702);
            this.guna2GradientPanel2.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 24);
            this.label1.TabIndex = 54;
            this.label1.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DisplayMember = "Category";
            this.cmbStatus.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Claimed",
            "Unclaimed"});
            this.cmbStatus.Location = new System.Drawing.Point(22, 502);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(299, 32);
            this.cmbStatus.TabIndex = 53;
            // 
            // txtFoundDate
            // 
            this.txtFoundDate.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoundDate.Location = new System.Drawing.Point(22, 293);
            this.txtFoundDate.Multiline = true;
            this.txtFoundDate.Name = "txtFoundDate";
            this.txtFoundDate.Size = new System.Drawing.Size(299, 34);
            this.txtFoundDate.TabIndex = 49;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelete.Location = new System.Drawing.Point(31, 630);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(290, 53);
            this.btnDelete.TabIndex = 48;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnUpdate.Location = new System.Drawing.Point(180, 571);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(141, 53);
            this.btnUpdate.TabIndex = 47;
            this.btnUpdate.Text = "Claim";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAdd.Location = new System.Drawing.Point(31, 571);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(143, 53);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtFounder
            // 
            this.txtFounder.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFounder.Location = new System.Drawing.Point(22, 430);
            this.txtFounder.Multiline = true;
            this.txtFounder.Name = "txtFounder";
            this.txtFounder.Size = new System.Drawing.Size(299, 34);
            this.txtFounder.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(18, 403);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 24);
            this.label8.TabIndex = 43;
            this.label8.Text = "Founder";
            // 
            // txtFoundLocation
            // 
            this.txtFoundLocation.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoundLocation.Location = new System.Drawing.Point(23, 361);
            this.txtFoundLocation.Multiline = true;
            this.txtFoundLocation.Name = "txtFoundLocation";
            this.txtFoundLocation.Size = new System.Drawing.Size(298, 34);
            this.txtFoundLocation.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(19, 334);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 24);
            this.label9.TabIndex = 41;
            this.label9.Text = "Found Location";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(18, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 24);
            this.label10.TabIndex = 37;
            this.label10.Text = "Date Found";
            // 
            // txtFoundDescription
            // 
            this.txtFoundDescription.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoundDescription.Location = new System.Drawing.Point(22, 168);
            this.txtFoundDescription.Multiline = true;
            this.txtFoundDescription.Name = "txtFoundDescription";
            this.txtFoundDescription.Size = new System.Drawing.Size(299, 89);
            this.txtFoundDescription.TabIndex = 36;
            // 
            // txtFoundName
            // 
            this.txtFoundName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoundName.Location = new System.Drawing.Point(22, 106);
            this.txtFoundName.Multiline = true;
            this.txtFoundName.Name = "txtFoundName";
            this.txtFoundName.Size = new System.Drawing.Size(299, 34);
            this.txtFoundName.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(18, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 24);
            this.label11.TabIndex = 35;
            this.label11.Text = "Item Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(18, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 24);
            this.label12.TabIndex = 34;
            this.label12.Text = "Item description";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(14, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(323, 43);
            this.label13.TabIndex = 33;
            this.label13.Text = "Manage Found Items";
            // 
            // dgvFoundItems
            // 
            this.dgvFoundItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvFoundItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFoundItems.Location = new System.Drawing.Point(33, 184);
            this.dgvFoundItems.Name = "dgvFoundItems";
            this.dgvFoundItems.RowHeadersWidth = 51;
            this.dgvFoundItems.RowTemplate.Height = 24;
            this.dgvFoundItems.Size = new System.Drawing.Size(640, 483);
            this.dgvFoundItems.TabIndex = 35;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BackgroundImage = global::FINAL_MINSUFINDER.Properties.Resources.image_Photoroom__46_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(469, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 28);
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DisplayMember = "Category";
            this.cmbCategory.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Item ID",
            "Item Name",
            "Description",
            "Date Lost",
            "Status"});
            this.cmbCategory.Location = new System.Drawing.Point(511, 128);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(148, 32);
            this.cmbCategory.TabIndex = 51;
            this.cmbCategory.Text = "All Categories";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(245, 128);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(250, 34);
            this.textBox6.TabIndex = 50;
            // 
            // FoundItemsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvFoundItems);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label4);
            this.Name = "FoundItemsUC";
            this.Size = new System.Drawing.Size(1038, 702);
            this.Load += new System.EventHandler(this.FoundItemsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoundItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.TextBox txtFoundDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtFounder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFoundLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFoundDescription;
        private System.Windows.Forms.TextBox txtFoundName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvFoundItems;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
    }
}
