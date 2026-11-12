using Guna.UI2.WinForms;
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
    public partial class LostItemsUC : UserControl
    {
        private int selectedLostItemID = -1;

        public LostItemsUC()
        {
            InitializeComponent();
        }

        private void LoadLostItems()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"SELECT LostItemID, ItemName,
                                     ItemDescription, DateLost,
                                     LastLocation, ItemOwner, Status
                                     FROM LostItems";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvLostItems.DataSource = dt;

                        // Hide the ID column
                        if (dgvLostItems.Columns["LostItemID"] != null)
                        {
                            dgvLostItems.Columns["LostItemID"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lost items: " + ex.Message);
            }
        }

        // FORM LOAD
        private void LostItemsUC_Load(object sender, EventArgs e)
        {
            LoadLostItems();
        }

        // ADD LOST ITEM
        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLostName.Text) ||
                string.IsNullOrWhiteSpace(txtLostDescription.Text) ||
                string.IsNullOrWhiteSpace(txtLostLocation.Text) ||
                string.IsNullOrWhiteSpace(txtOwner.Text) ||
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

                    string query = @"INSERT INTO LostItems
                                    (ItemName, ItemDescription, DateLost,
                                     LastLocation, ItemOwner, Status)
                                    VALUES
                                    (@ItemName, @ItemDescription, @DateLost,
                                     @LastLocation, @Owner, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", txtLostName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemDescription", txtLostDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateLost", dtpLostDate.Value);
                        cmd.Parameters.AddWithValue("@LastLocation", txtLostLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Owner", txtOwner.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Lost item reported successfully!");

                LoadLostItems();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding lost item: " + ex.Message);
            }
        }

        // CLEAR FIELDS METHOD
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

        // DELETE LOST ITEM
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedLostItemID == -1)
            {
                MessageBox.Show("Please select a lost item to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this lost item?",
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

                        string query = @"DELETE FROM LostItems WHERE LostItemID = @ID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ID", selectedLostItemID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Lost item deleted successfully!");
                                LoadLostItems();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Lost item not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting lost item: " + ex.Message);
                }
            }
        }

        // CLICK GRID ROW TO POPULATE FIELDS
        private void dgvLostItems_CellClick(object sender, DataGridViewCellEventArgs e)
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

        // UPDATE LOST ITEM
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedLostItemID == -1)
            {
                MessageBox.Show("Please select a lost item to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLostName.Text) ||
                string.IsNullOrWhiteSpace(txtLostDescription.Text) ||
                string.IsNullOrWhiteSpace(txtLostLocation.Text) ||
                string.IsNullOrWhiteSpace(txtOwner.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to update this lost item?",
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

                        string query = @"UPDATE LostItems
                                        SET ItemName = @ItemName,
                                            ItemDescription = @Description,
                                            DateLost = @DateLost,
                                            LastLocation = @Location,
                                            ItemOwner = @Owner,
                                            Status = @Status
                                        WHERE LostItemID = @ID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ItemName", txtLostName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Description", txtLostDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@DateLost", dtpLostDate.Value);
                            cmd.Parameters.AddWithValue("@Location", txtLostLocation.Text.Trim());
                            cmd.Parameters.AddWithValue("@Owner", txtOwner.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                            cmd.Parameters.AddWithValue("@ID", selectedLostItemID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Lost item updated successfully!");
                                LoadLostItems();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Lost item not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating lost item: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedLostItemID == -1)
            {
                MessageBox.Show("Please select a lost item to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this lost item?",
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

                        string query = @"DELETE FROM LostItems WHERE LostItemID = @ID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ID", selectedLostItemID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Lost item deleted successfully!");
                                LoadLostItems();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Lost item not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting lost item: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (selectedLostItemID == -1)
            {
                MessageBox.Show("Please select a lost item to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLostName.Text) ||
                string.IsNullOrWhiteSpace(txtLostDescription.Text) ||
                string.IsNullOrWhiteSpace(txtLostLocation.Text) ||
                string.IsNullOrWhiteSpace(txtOwner.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to update this lost item?",
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

                        string query = @"UPDATE LostItems
                                SET ItemName = @ItemName,
                                    ItemDescription = @Description,
                                    DateLost = @DateLost,
                                    LastLocation = @Location,
                                    ItemOwner = @Owner,
                                    Status = @Status
                                WHERE LostItemID = @ID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ItemName", txtLostName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Description", txtLostDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@DateLost", dtpLostDate.Value);
                            cmd.Parameters.AddWithValue("@Location", txtLostLocation.Text.Trim());
                            cmd.Parameters.AddWithValue("@Owner", txtOwner.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                            cmd.Parameters.AddWithValue("@ID", selectedLostItemID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Lost item updated successfully!");
                                LoadLostItems();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Lost item not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating lost item: " + ex.Message);
                }
            }
        }


        private void btnClear_Click_1(object sender, EventArgs e)
        {
            Found found = new Found();
            found.Show();
        }

        private void dgvLostItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvLostItems_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvLostItems.Rows[e.RowIndex];

            selectedLostItemID = Convert.ToInt32(
                row.Cells["LostItemID"].Value
            );

            txtLostName.Text = Convert.ToString(
                row.Cells["ItemName"].Value
            );

            txtLostDescription.Text = Convert.ToString(
                row.Cells["ItemDescription"].Value
            );

            if (row.Cells["DateLost"].Value != DBNull.Value)
            {
                dtpLostDate.Value = Convert.ToDateTime(
                    row.Cells["DateLost"].Value
                );
            }

            txtLostLocation.Text = Convert.ToString(
                row.Cells["LastLocation"].Value
            );

            txtOwner.Text = Convert.ToString(
                row.Cells["ItemOwner"].Value
            );

            cmbStatus.Text = Convert.ToString(
                row.Cells["Status"].Value
            );
        }
    }
}