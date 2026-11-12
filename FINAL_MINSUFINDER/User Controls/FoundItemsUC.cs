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

                        // Hide the automatically generated ID
                        dgvFoundItems.Columns["FoundItemID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading found items: " + ex.Message);
            }
        }

        // FORM LOAD
        private void FoundItemsUC_Load(object sender, EventArgs e)
        {
            LoadFoundItems();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoundName.Text) ||
               string.IsNullOrWhiteSpace(txtFoundDescription.Text) ||
               string.IsNullOrWhiteSpace(txtFoundLocation.Text) ||
               string.IsNullOrWhiteSpace(txtFounder.Text) ||
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

                        // Use the DateTimePicker's selected value instead of DateTime.Now
                        cmd.Parameters.AddWithValue("@DateFound",
                            dtpFoundDate.Value);

                        cmd.Parameters.AddWithValue("@FoundLocation",
                            txtFoundLocation.Text.Trim());

                        cmd.Parameters.AddWithValue("@Founder",
                            txtFounder.Text.Trim());

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

            // Reset DateTimePicker back to current date/time on clear
            dtpFoundDate.Value = DateTime.Now;

            txtFoundLocation.Clear();
            txtFounder.Clear();

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

                if (row.Cells["FoundItemID"].Value == null)
                    return;

                selectedFoundItemID =
                    Convert.ToInt32(row.Cells["FoundItemID"].Value);

                txtFoundName.Text =
                    Convert.ToString(row.Cells["ItemName"].Value);

                txtFoundDescription.Text =
                    Convert.ToString(row.Cells["ItemDescription"].Value);

                // Load the date from the grid directly into the DateTimePicker
                if (row.Cells["DateFound"].Value != DBNull.Value)
                {
                    dtpFoundDate.Value = Convert.ToDateTime(row.Cells["DateFound"].Value);
                }

                txtFoundLocation.Text =
                    Convert.ToString(row.Cells["FoundLocation"].Value);

                txtFounder.Text =
                    Convert.ToString(row.Cells["Founder"].Value);

                cmbStatus.Text =
                    Convert.ToString(row.Cells["Status"].Value);
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
                string.IsNullOrWhiteSpace(txtFounder.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to update this found item?",
                "Confirm Update",
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

                        // Added DateFound = @DateFound so updates can change the date as well
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
                            cmd.Parameters.AddWithValue("@ItemName",
                                txtFoundName.Text.Trim());

                            cmd.Parameters.AddWithValue("@Description",
                                txtFoundDescription.Text.Trim());

                            cmd.Parameters.AddWithValue("@DateFound",
                                dtpFoundDate.Value);

                            cmd.Parameters.AddWithValue("@Location",
                                txtFoundLocation.Text.Trim());

                            cmd.Parameters.AddWithValue("@Founder",
                                txtFounder.Text.Trim());

                            cmd.Parameters.AddWithValue("@Status",
                                cmbStatus.Text);

                            cmd.Parameters.AddWithValue("@ID",
                                selectedFoundItemID);

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
            ClaimForm claimForm = new ClaimForm();
            claimForm.Show();
        }
    }
}