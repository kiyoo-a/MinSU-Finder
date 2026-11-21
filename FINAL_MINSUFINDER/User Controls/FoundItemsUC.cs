using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_MINSUFINDER.User_Controls
{
    public partial class FoundItemsUC : UserControl
    {
        private int selectedFoundItemID = -1;
        private string selectedImagePath = null; 

        public FoundItemsUC()
        {
            InitializeComponent();
        }

        private void LoadFoundItems()
        {
            UserDatabaseHelper.LoadFoundItems(dgvFoundItems);
        }

        private void FoundItemsUC_Load(object sender, EventArgs e)
        {
            LoadFoundItems();
        }

        // ADD BUTTON
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoundName.Text) ||
        string.IsNullOrWhiteSpace(txtFoundDescription.Text) ||
        string.IsNullOrWhiteSpace(txtFoundLocation.Text) ||
        string.IsNullOrWhiteSpace(txtFinder.Text) ||
        string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please complete all required fields.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UserDatabaseHelper.AddFoundItem(
                txtFoundName.Text.Trim(),
                txtFoundDescription.Text.Trim(),
                dtpFoundDate.Value,
                txtFoundLocation.Text.Trim(),
                txtFinder.Text.Trim(),
                cmbStatus.Text,
                selectedImagePath))
            {
                MessageBox.Show("Found item added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadFoundItems();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtFoundName.Clear();
            txtFoundDescription.Clear();
            dtpFoundDate.Value = DateTime.Now;
            txtFoundLocation.Clear();
            txtFinder.Clear();
            cmbStatus.SelectedIndex = -1;
            selectedFoundItemID = -1;
            dgvFoundItems.ClearSelection();
        }

        // UPDATE BUTTON
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedFoundItemID == -1)
            {
                MessageBox.Show("Please select a found item from the table to update.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFoundName.Text) ||
                string.IsNullOrWhiteSpace(txtFoundDescription.Text) ||
                string.IsNullOrWhiteSpace(txtFoundLocation.Text) ||
                string.IsNullOrWhiteSpace(txtFinder.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please complete all fields.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to update this found item?",
                "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (UserDatabaseHelper.UpdateFoundItem(
                    selectedFoundItemID,
                    txtFoundName.Text.Trim(),
                    txtFoundDescription.Text.Trim(),
                    dtpFoundDate.Value,
                    txtFoundLocation.Text.Trim(),
                    txtFinder.Text.Trim(),
                    cmbStatus.Text,
                    selectedImagePath)) // ADD THIS
                {
                    MessageBox.Show("Found item updated successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadFoundItems();
                    ClearFields();
                }
            }
        }

        // DELETE BUTTON
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedFoundItemID == -1)
            {
                MessageBox.Show("Please select a found item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this found item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (UserDatabaseHelper.DeleteFoundItem(selectedFoundItemID))
                {
                    MessageBox.Show("Found item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFoundItems();
                    ClearFields();
                }
            }
        }

        // CLAIM BUTTON
        private void btnCLaim_Click(object sender, EventArgs e)
        {
            if (selectedFoundItemID == -1)
            {
                MessageBox.Show("Please select an item from the Found Items list to claim.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Siguraduhing kasama ang selectedFoundItemID dito!
            ClaimForm claimForm = new ClaimForm(txtFoundName.Text.Trim(), txtFinder.Text.Trim(), selectedFoundItemID);
            claimForm.ShowDialog();

            // I-refresh ang table pagkatapos i-submit ang claim
            LoadFoundItems();
            ClearFields();
        }

        // CELL CLICK
        private void dgvFoundItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFoundItems.Rows[e.RowIndex];

                if (row.Cells["FoundItemID"].Value == null || row.Cells["FoundItemID"].Value == DBNull.Value)
                    return;

                selectedFoundItemID = Convert.ToInt32(row.Cells["FoundItemID"].Value);
                txtFoundName.Text = Convert.ToString(row.Cells["ItemName"].Value);
                txtFoundDescription.Text = Convert.ToString(row.Cells["ItemDescription"].Value);

                if (row.Cells["DateFound"].Value != DBNull.Value)
                {
                    dtpFoundDate.Value = Convert.ToDateTime(row.Cells["DateFound"].Value);
                }

                txtFoundLocation.Text = Convert.ToString(row.Cells["FoundLocation"].Value);
                txtFinder.Text = Convert.ToString(row.Cells["Founder"].Value);
                cmbStatus.Text = Convert.ToString(row.Cells["Status"].Value);
                selectedImagePath = Convert.ToString(row.Cells["ImagePath"].Value);

                DisplayImage(selectedImagePath);
            }
        }

        // SEARCH BAR
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (dgvFoundItems.DataSource is DataTable dt)
            {
                string searchValue = txtSearch.Text.Trim().Replace("'", "''");

                if (string.IsNullOrEmpty(searchValue))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    dt.DefaultView.RowFilter = string.Format(
                        "ItemName LIKE '%{0}%' OR ItemDescription LIKE '%{0}%' OR FoundLocation LIKE '%{0}%' OR Founder LIKE '%{0}%'",
                        searchValue);
                }
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.Combine(
                        Application.StartupPath, "ItemImages");

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string fileName = Guid.NewGuid().ToString()
                        + Path.GetExtension(ofd.FileName);

                    string destinationPath = Path.Combine(folderPath, fileName);

                    File.Copy(ofd.FileName, destinationPath, true);

                    selectedImagePath = Path.Combine("ItemImages", fileName);

                    DisplayImage(selectedImagePath);
                }
            }
        }

        private void DisplayImage(string imagePath)
        {
            if (picItem.Image != null)
            {
                picItem.Image.Dispose();
                picItem.Image = null;
            }

            if (string.IsNullOrEmpty(imagePath))
                return;

            string fullPath = Path.Combine(
                Application.StartupPath, imagePath);

            if (File.Exists(fullPath))
            {
                using (Image img = Image.FromFile(fullPath))
                {
                    picItem.Image = new Bitmap(img);
                }
            }
        }

        private void picItem_Click(object sender, EventArgs e)
        {
            if (picItem.Image == null)
                return;

            using (ImageViewer viewer = new ImageViewer(picItem.Image))
            {
                viewer.ShowDialog();
            }
        }
    }
}