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
        public FoundItemsUC()
        {
            InitializeComponent();
        }

        private void LoadFoundItems()
        {
            DatabaseConnection db = new DatabaseConnection();

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();

                string query = @"SELECT ItemName, ItemDescription, DateFound,
                                FoundLocation, Founder, Status
                         FROM FoundItems";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvFoundItems.DataSource = dt;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

                
            
        }

        private void FoundItemsUC_Load(object sender, EventArgs e)
        {
            LoadFoundItems();
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
                    cmd.Parameters.AddWithValue("@ItemName", txtFoundName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ItemDescription", txtFoundDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateFound", DateTime.Now);
                    cmd.Parameters.AddWithValue("@FoundLocation", txtFoundLocation.Text.Trim());
                    cmd.Parameters.AddWithValue("@Founder", txtFounder.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    cmd.ExecuteNonQuery();



                    MessageBox.Show("Found item added successfully!");

                    LoadFoundItems();
                }
            }
        }
    }
}
