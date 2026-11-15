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
    public partial class ClaimForm : Form
    {
        public string PassedItemName { get; set; }
        public string PassedFounder { get; set; }
        
        public ClaimForm()
        {
            InitializeComponent();
        }
        public ClaimForm(string itemName, string founderName)
        {
            InitializeComponent();

            // Direktang ilagay sa text box pagbukas na pagbukas pa lang ng form
            txtItemName.Text = itemName;
            txtFinderFullName.Text = founderName;    // Siguraduhing ito ang eksaktong pangalan ng text box para sa Item Name
                                                 // txtFinderName.Text = founderName; // Alisin ang comment '//' kung may text box ka para sa Finder Name
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
        string.IsNullOrWhiteSpace(txtFinderFullName.Text) ||
        string.IsNullOrWhiteSpace(txtOwnerFullName.Text))
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

                    string query = @"
                INSERT INTO Claims
                (ItemName, OwnerFullName, ClaimantFullName, DateClaimed)
                VALUES
                (@ItemName, @Owner, @Claimant, @DateClaimed)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ItemName",
                            txtItemName.Text.Trim());

                        cmd.Parameters.AddWithValue("@Owner",
                            txtOwnerFullName.Text.Trim());

                        cmd.Parameters.AddWithValue("@Claimant",
                            txtFinderFullName.Text.Trim());

                        cmd.Parameters.AddWithValue("@DateClaimed",
                            dtpDateClaimed.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Claim recorded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error recording claim: " + ex.Message);
            }
            this.Hide();
        }

        private void ClaimForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
