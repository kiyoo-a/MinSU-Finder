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

namespace FINAL_MINSUFINDER
{
    public partial class Found : Form
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public DateTime DateFound { get; set; }
        public string FoundLocation { get; set; }
        public int LostItemID { get; set; }
        public string Status { get; set; }
        public Found()
        {
            InitializeComponent();
        }



        public void clearFields()
        {
            txtFoundName.Clear();
            txtFoundDescription.Clear();
            txtFoundLocation.Clear();
            txtFounder.Clear();
            dtpFoundDate.Value = DateTime.Now;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoundName.Text) || string.IsNullOrWhiteSpace(txtFoundDescription.Text) ||
                string.IsNullOrWhiteSpace(txtFoundLocation.Text) || string.IsNullOrWhiteSpace(txtFounder.Text))
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

                    string insertQuery = @"INSERT INTO FoundItems (ItemName, ItemDescription, DateFound, FoundLocation, Founder, Status)
                                           VALUES (@ItemName, @ItemDescription, @DateFound, @FoundLocation, @Founder, 'Unclaimed')";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", txtFoundName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemDescription", txtFoundDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateFound", dtpFoundDate.Value);
                        cmd.Parameters.AddWithValue("@FoundLocation", txtFoundLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Founder", txtFounder.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    if (LostItemID != -1)
                    {
                        string updateQuery = "UPDATE LostItems SET Status = 'Found' WHERE LostItemID = @ID";
                        using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, con))
                        {
                            cmdUpdate.Parameters.AddWithValue("@ID", LostItemID);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Found item added and status updated successfully!");

                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding found item: " + ex.Message);
            }
            this.Hide();
        }
        private void Found_Load(object sender, EventArgs e)
        {
            txtFoundName.Text = ItemName;         
            txtFoundDescription.Text = ItemDescription; 
            dtpFoundDate.Value = DateFound;    
            txtFoundLocation.Text = FoundLocation;
            cmbStatus.Text = Status;   
        }

        private void txtFoundDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
