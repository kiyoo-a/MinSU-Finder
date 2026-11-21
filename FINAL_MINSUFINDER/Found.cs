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
        public int LostItemID { get; set; } = -1;
        public string Status { get; set; }
        public string ImagePath { get; set; }

        public Found()
        {
            InitializeComponent();
        }

        private void Found_Load(object sender, EventArgs e)
        {
            txtFoundName.Text = ItemName;
            txtFoundDescription.Text = ItemDescription;
            dtpFoundDate.Value = (DateFound > dtpFoundDate.MinDate) ? DateFound : DateTime.Now;
            txtFoundLocation.Text = FoundLocation;
            cmbStatus.Text = Status;
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoundName.Text) || string.IsNullOrWhiteSpace(txtFoundDescription.Text) ||
                string.IsNullOrWhiteSpace(txtFoundLocation.Text) || string.IsNullOrWhiteSpace(txtFinder.Text))
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UserDatabaseHelper.AddFoundItem(txtFoundName.Text.Trim(), txtFoundDescription.Text.Trim(),
                dtpFoundDate.Value, txtFoundLocation.Text.Trim(), txtFinder.Text.Trim(),"Unclaimed", ImagePath, LostItemID))
            {
                MessageBox.Show("Found item added and status updated successfully!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        public void ClearFields()
        {
            txtFoundName.Clear();
            txtFoundDescription.Clear();
            txtFoundLocation.Clear();
            txtFinder.Clear();
            dtpFoundDate.Value = DateTime.Now;
        }
    }
}