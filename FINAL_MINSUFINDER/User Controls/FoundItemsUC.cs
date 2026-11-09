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
        private int currentUserID = 1;

        public FoundItemsUC()
        {
            InitializeComponent();
        }

        private void LoadFoundItems()
        {
            DatabaseConnection db = new DatabaseConnection();

            using (SqlConnection con = db.GetConnection())
            {
                string query = "SELECT * FROM FoundItems";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dgvFoundItems.DataSource = dt;
                }
            }
        }



        private void ClearFields()
        {
            txtFoundName.Clear();
            txtFoundDescription.Clear();
            txtFoundDate.Clear();
            txtFoundLocation.Clear();
            txtFounder.Clear();

            cmbStatus.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

                
            
        }

        private void FoundItemsUC_Load(object sender, EventArgs e)
        {
           
        
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Unclaimed");
            cmbStatus.Items.Add("Claimed");

            cmbStatus.SelectedIndex = 0;

            LoadFoundItems();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoundName.Text) ||
       string.IsNullOrWhiteSpace(txtFoundDescription.Text) ||
       string.IsNullOrWhiteSpace(txtFoundDate.Text) ||
       string.IsNullOrWhiteSpace(txtFoundLocation.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Validate date
            DateTime dateFound;

            if (!DateTime.TryParse(txtFoundDate.Text, out dateFound))
            {
                MessageBox.Show("Please enter a valid date.");
                return;
            }

            // Get status
            string status = string.IsNullOrWhiteSpace(cmbStatus.Text)
                ? "Unclaimed"
                : cmbStatus.Text;

            if (status != "Unclaimed" && status != "Claimed")
            {
                MessageBox.Show("Please select a valid status.");
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                INSERT INTO FoundItems
                (UserID, ItemName, Description, Location,
                 DateFound, Status, DateReported)
                VALUES
                (@UserID, @ItemName, @Description, @Location,
                 @DateFound, @Status, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = currentUserID;

                        cmd.Parameters.AddWithValue(
                            "@ItemName", txtFoundName.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Description", txtFoundDescription.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Location", txtFoundLocation.Text.Trim());

                        cmd.Parameters.Add("@DateFound", SqlDbType.Date).Value = dateFound;

                        cmd.Parameters.AddWithValue("@Status", status);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Found item successfully saved!");

                ClearFields();

                LoadFoundItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
    
}
