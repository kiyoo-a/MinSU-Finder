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

namespace FINAL_MINSUFINDER.User_Controls
{
    public partial class FoundItemsUC : UserControl
    {
        private int selectedFoundItemID = -1;
        public FoundItemsUC()
        {
            InitializeComponent();
        }

        private void LoadFoundItems()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"SELECT FoundItemID, ItemName,
                                     ItemDescription, DateFound,
                                     FoundLocation, Founder, Status
                                     FROM FoundItems";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvFoundItems.DataSource = dt;

                        dgvFoundItems.Columns["FoundItemID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading found items: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoundName.Text) ||
               string.IsNullOrWhiteSpace(txtFoundDescription.Text) ||
               string.IsNullOrWhiteSpace(txtFoundLocation.Text) ||
               string.IsNullOrWhiteSpace(txtFinder.Text) ||
               string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"INSERT INTO FoundItems
                                    (ItemName, ItemDescription, DateFound,
                                     FoundLocation, Founder, Status)
                                    VALUES
                                    (@ItemName, @ItemDescription, @DateFound,
                                     @FoundLocation, @Founder, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ItemName",
                            txtFoundName.Text.Trim());

                        cmd.Parameters.AddWithValue("@ItemDescription",
                            txtFoundDescription.Text.Trim());

                        cmd.Parameters.AddWithValue("@DateFound",
                            dtpFoundDate.Value);

                        cmd.Parameters.AddWithValue("@FoundLocation",
                            txtFoundLocation.Text.Trim());

                        cmd.Parameters.AddWithValue("@Founder",
                            txtFinder.Text.Trim());

                        cmd.Parameters.AddWithValue("@Status",
                            cmbStatus.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Found item added successfully!");

                LoadFoundItems();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding found item: " + ex.Message);
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



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedFoundItemID == -1)
            {
                MessageBox.Show("Please select a found item to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this found item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseConnection db = new DatabaseConnection();

                    using (SqlConnection con = db.GetConnection())
                    {
                        con.Open();

                        string query = @"DELETE FROM FoundItems
                                         WHERE FoundItemID = @ID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ID",
                                selectedFoundItemID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Found item deleted successfully!");

                                LoadFoundItems();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Found item not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting found item: " + ex.Message);
                }
            }
        }

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
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedFoundItemID == -1)
            {
                MessageBox.Show("Please select a found item to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFoundName.Text) ||
                string.IsNullOrWhiteSpace(txtFoundDescription.Text) ||
                string.IsNullOrWhiteSpace(txtFoundLocation.Text) ||
                string.IsNullOrWhiteSpace(txtFinder.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            DialogResult result = MessageBox.Show( "Are you sure you want " +
                "to update this found item?", "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseConnection db = new DatabaseConnection();

                    using (SqlConnection con = db.GetConnection())
                    {
                        con.Open();
                        string query = @"UPDATE FoundItems
                                        SET ItemName = @ItemName,
                                            ItemDescription = @Description,
                                            DateFound = @DateFound,
                                            FoundLocation = @Location,
                                            Founder = @Founder,
                                            Status = @Status
                                        WHERE FoundItemID = @ID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ItemName", txtFoundName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Description", txtFoundDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@DateFound", dtpFoundDate.Value);
                            cmd.Parameters.AddWithValue("@Location", txtFoundLocation.Text.Trim());
                            cmd.Parameters.AddWithValue("@Founder", txtFinder.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                            cmd.Parameters.AddWithValue("@ID", selectedFoundItemID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Found item updated successfully!");

                                LoadFoundItems();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Found item not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating found item: " + ex.Message);
                }
            }
        }

        private void btnCLaim_Click(object sender, EventArgs e)
        {

            if (selectedFoundItemID == -1)
            {
                MessageBox.Show("Please select an item from the Found Items list to claim.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string itemName = txtFoundName.Text.Trim();
            string founder = txtFinder.Text.Trim();

            ClaimForm claimForm = new ClaimForm(itemName, founder);
            claimForm.ShowDialog();
        }

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
                    dt.DefaultView.RowFilter = string.Format( "ItemName LIKE '%{0}%' OR" +
                        " ItemDescription LIKE '%{0}%' OR " + "FoundLocation LIKE '%{0}%' OR Founder LIKE '%{0}%'",
                        searchValue);
                }
            }
        }

        private void FoundItemsUC_Load(object sender, EventArgs e)
        {
            LoadFoundItems();
        }
    }
}