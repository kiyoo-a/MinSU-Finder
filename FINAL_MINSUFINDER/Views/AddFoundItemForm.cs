using System;
using System.Drawing;
using System.Windows.Forms;
using FINAL_MINSUFINDER.Model;

namespace FINAL_MINSUFINDER.Views
{
    public partial class AddFoundItemForm : Form
    {
        public Item ResultItem { get; private set; }
        private string selectedImagePath = "";

        private TextBox txtItemName;
        private TextBox txtCategory;
        private TextBox txtLocation;
        private TextBox txtDescription;
        private PictureBox pbPreview;
        private Button btnBrowse;
        private Button btnSave;
        private Button btnCancel;

        public AddFoundItemForm()
        {
            InitializeCustomForm();
        }

        private void InitializeCustomForm()
        {
            this.Text = "Add Found Item";
            this.Size = new Size(420, 480);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Header Label
            Label lblHeader = new Label
            {
                Text = "Register Found Item",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Location = new Point(20, 20),
                Size = new Size(360, 30)
            };
            this.Controls.Add(lblHeader);

            // Item Name
            this.Controls.Add(CreateLabel("Item Name:", new Point(20, 65)));
            txtItemName = CreateTextBox(new Point(20, 90));
            this.Controls.Add(txtItemName);

            // Category
            this.Controls.Add(CreateLabel("Category:", new Point(20, 130)));
            txtCategory = CreateTextBox(new Point(20, 155));
            this.Controls.Add(txtCategory);

            // Location
            this.Controls.Add(CreateLabel("Found Location:", new Point(20, 195)));
            txtLocation = CreateTextBox(new Point(20, 220));
            this.Controls.Add(txtLocation);

            // Description
            this.Controls.Add(CreateLabel("Description:", new Point(20, 260)));
            txtDescription = CreateTextBox(new Point(20, 285));
            txtDescription.Height = 50;
            txtDescription.Multiline = true;
            this.Controls.Add(txtDescription);

            // Picture Preview
            pbPreview = new PictureBox
            {
                Location = new Point(250, 90),
                Size = new Size(135, 120),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(245, 245, 245)
            };
            this.Controls.Add(pbPreview);

            // Browse Button
            btnBrowse = new Button
            {
                Text = "Upload Photo",
                Location = new Point(250, 220),
                Size = new Size(135, 30),
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnBrowse.Click += BtnBrowse_Click;
            this.Controls.Add(btnBrowse);

            // Save Button
            btnSave = new Button
            {
                Text = "Save Item",
                Location = new Point(200, 370),
                Size = new Size(90, 35),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // Cancel Button
            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(295, 370),
                Size = new Size(90, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnCancel);
        }

        private Label CreateLabel(string text, Point loc)
        {
            return new Label
            {
                Text = text,
                Location = loc,
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.Black
            };
        }

        private TextBox CreateTextBox(Point loc)
        {
            return new TextBox
            {
                Location = loc,
                Size = new Size(210, 25),
                Font = new Font("Segoe UI", 10F)
            };
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFile.FileName;
                pbPreview.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter the item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gumawa ng bagong Item object
            ResultItem = new Item(
                txtItemName.Text.Trim(),
                txtCategory.Text.Trim(),
                txtLocation.Text.Trim(),
                DateTime.Now,
                selectedImagePath,
                txtDescription.Text.Trim()
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}