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

        // Constructor na tumatanggap ng Item Name at Finder/Founder Name
        public ClaimForm(string itemName, string founderName)
        {
            InitializeComponent();

            PassedItemName = itemName;
            PassedFounder = founderName;

            txtItemName.Text = itemName;
            txtFinder.Text = founderName;    // Nailagay na ang Finder Name
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validation: Siguraduhing walang blangko sa mga mahalagang fields
            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
                string.IsNullOrWhiteSpace(txtFinder.Text) ||
                string.IsNullOrWhiteSpace(txtClaimant.Text))
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    // SQL Query para i-save ang lahat ng impormasyon sa tamang mga kolum
                    string query = @"INSERT INTO Claims (ItemName, OwnerFullName, FinderFullName, ClaimantFullName, DateClaimed)
                                     VALUES (@ItemName, @OwnerFullName, @FinderFullName, @ClaimantFullName, @DateClaimed)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text.Trim());

                        // Kolum para sa Owner (Pwede mong palitan ng txtOwnerFullName.Text kung may hiwalay kang textbox para rito)
                        cmd.Parameters.AddWithValue("@OwnerFullName", txtClaimant.Text.Trim());

                        // Kolum para sa Finder Name (galing sa txtFinder)
                        cmd.Parameters.AddWithValue("@FinderFullName", txtFinder.Text.Trim());

                        // Kolum para sa Claimant Name (galing sa txtClaimant)
                        cmd.Parameters.AddWithValue("@ClaimantFullName", txtClaimant.Text.Trim());

                        // Petsa kung kailan claim
                        cmd.Parameters.AddWithValue("@DateClaimed", dtpDateClaimed.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Claim submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting claim: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClaimForm_Load(object sender, EventArgs e)
        {
            // Itakda ang kasalukuyang petsa at oras sa DateTimePicker pagbukas
            dtpDateClaimed.Value = DateTime.Now;
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}