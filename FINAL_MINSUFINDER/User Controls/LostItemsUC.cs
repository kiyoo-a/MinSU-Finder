using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace FINAL_MINSUFINDER.User_Controls
{
    public partial class LostItemsUC : UserControl
    {
        private int selectedLostItemID = -1;

        public LostItemsUC()
        {
            InitializeComponent();
        }

        private void LoadLostItems()
        {
            UserDatabaseHelper.LoadLostItems(dgvLostItems);
        }

        private void LostItemsUC_Load(object sender, EventArgs e)
        {
            LoadLostItems();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLostName.Text) ||
                string.IsNullOrWhiteSpace(txtLostDescription.Text) ||
                string.IsNullOrWhiteSpace(txtLostLocation.Text) ||
                string.IsNullOrWhiteSpace(txtOwner.Text))
            {
                MessageBox.Show("Please complete all required fields.");
                return;
            }

            if (UserDatabaseHelper.AddLostItem(txtLostName.Text, txtLostDescription.Text, dtpLostDate.Value, txtLostLocation.Text, txtOwner.Text, cmbStatus.Text))
            {
                MessageBox.Show("Lost item added successfully!");
                LoadLostItems();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtLostName.Clear();
            txtLostDescription.Clear();
            dtpLostDate.Value = DateTime.Now;
            txtLostLocation.Clear();
            txtOwner.Clear();
            cmbStatus.SelectedIndex = -1;
            selectedLostItemID = -1;
            dgvLostItems.ClearSelection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void UpdateProcess()
        {
            if (selectedLostItemID == -1)
            {
                MessageBox.Show("Please select a lost item from the table first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLostName.Text) ||
                string.IsNullOrWhiteSpace(txtLostDescription.Text) ||
                string.IsNullOrWhiteSpace(txtLostLocation.Text) ||
                string.IsNullOrWhiteSpace(txtOwner.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to update this lost item?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (UserDatabaseHelper.UpdateLostItem(selectedLostItemID, txtLostName.Text, txtLostDescription.Text, dtpLostDate.Value, txtLostLocation.Text, txtOwner.Text, cmbStatus.Text))
                {
                    MessageBox.Show("Lost item updated successfully!");
                    LoadLostItems();
                    ClearFields();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProcess();
        }

        private void DeleteProcess()
        {
            if (selectedLostItemID == -1)
            {
                MessageBox.Show("Please select a lost item to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this lost item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (UserDatabaseHelper.DeleteLostItem(selectedLostItemID))
                {
                    MessageBox.Show("Lost item deleted successfully!");
                    LoadLostItems();
                    ClearFields();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProcess();
        }

        private void SelectRow(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLostItems.Rows[e.RowIndex];

                if (row.Cells["LostItemID"].Value == null || row.Cells["LostItemID"].Value == DBNull.Value)
                    return;

                selectedLostItemID = Convert.ToInt32(row.Cells["LostItemID"].Value);
                txtLostName.Text = Convert.ToString(row.Cells["ItemName"].Value);
                txtLostDescription.Text = Convert.ToString(row.Cells["ItemDescription"].Value);

                if (row.Cells["DateLost"].Value != DBNull.Value)
                {
                    dtpLostDate.Value = Convert.ToDateTime(row.Cells["DateLost"].Value);
                }

                txtLostLocation.Text = Convert.ToString(row.Cells["LastLocation"].Value);
                txtOwner.Text = Convert.ToString(row.Cells["ItemOwner"].Value);
                cmbStatus.Text = Convert.ToString(row.Cells["Status"].Value);
            }
        }

        private void dgvLostItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow(e);
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            if (selectedLostItemID == -1)
            {
                MessageBox.Show("Please select an item from the Lost Items list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Found found = new Found();
            found.ItemName = txtLostName.Text.Trim();
            found.ItemDescription = txtLostDescription.Text.Trim();
            found.DateFound = dtpLostDate.Value;
            found.FoundLocation = txtLostLocation.Text.Trim();
            found.Status = "Found";
            found.LostItemID = selectedLostItemID;

            found.ShowDialog();

            LoadLostItems();
            ClearFields();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (dgvLostItems.DataSource is DataTable dt)
            {
                string searchValue = txtSearch.Text.Trim().Replace("'", "''");

                if (string.IsNullOrEmpty(searchValue))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    dt.DefaultView.RowFilter = string.Format(
                        "ItemName LIKE '%{0}%' OR ItemDescription LIKE '%{0}%' OR LastLocation LIKE '%{0}%' OR ItemOwner LIKE '%{0}%'", searchValue);
                }
            }
        }
    }
}