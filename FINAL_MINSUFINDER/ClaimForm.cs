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
        public int FoundItemID { get; set; } = -1;

        public ClaimForm()
        {
            InitializeComponent();
        }

        public ClaimForm(string itemName, string founderName, int foundItemID = -1)
        {
            InitializeComponent();
            PassedItemName = itemName;
            PassedFounder = founderName;
            FoundItemID = foundItemID;

            txtItemName.Text = itemName;
            txtFinder.Text = founderName;
        }

        private void ClaimForm_Load(object sender, EventArgs e)
        {
            dtpDateClaimed.Value = DateTime.Now;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
                string.IsNullOrWhiteSpace(txtFinder.Text) ||
                string.IsNullOrWhiteSpace(txtClaimant.Text))
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UserDatabaseHelper.SubmitClaim(
                txtItemName.Text.Trim(),
                txtClaimant.Text.Trim(),
                txtFinder.Text.Trim(),
                txtClaimant.Text.Trim(),
                dtpDateClaimed.Value,
                FoundItemID))
            {
                MessageBox.Show("Claim submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}