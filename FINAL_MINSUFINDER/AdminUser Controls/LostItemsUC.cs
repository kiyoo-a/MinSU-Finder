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
        public LostItemsUC()
        {
            InitializeComponent();
        }

        private void LoadLostItems()
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

                    dgvLostItems.DataSource = dt;
                }
            }
        }

        private void LostItemsUC_Load(object sender, EventArgs e)
        {

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

            DatabaseConnection db = new DatabaseConnection();

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();

                string query = @"INSERT INTO LostItems
        (ItemName, ItemDescription, DateLost, LastLocation, ItemOwner, Status)
        VALUES
        (@ItemName, @ItemDescription, @DateLost, @LastLocation, @Owner, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ItemName", txtLostName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ItemDescription", txtLostDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateLost", DateTime.Now);
                    cmd.Parameters.AddWithValue("@LastLocation", txtLostLocation.Text.Trim());
                    cmd.Parameters.AddWithValue("@Owner", txtOwner.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", "Lost");

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Lost item reported successfully!");

                    LoadLostItems();
                }
            }
        }
    }
}
