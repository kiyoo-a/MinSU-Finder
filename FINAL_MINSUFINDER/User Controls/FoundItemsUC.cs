using FINAL_MINSUFINDER.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FINAL_MINSUFINDER.Model;
using FINAL_MINSUFINDER.Views;

namespace FINAL_MINSUFINDER.User_Controls
{
    public partial class FoundItemsUC : UserControl
    {
        public FoundItemsUC()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            using (AddFoundItemForm addForm = new AddFoundItemForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    Item newItem = addForm.ResultItem;

                    // Gagawin ang Card gamit ang item na pinasa mula sa form
                    ItemCard card = new ItemCard(newItem);

                    // Event para sa View Details at Claim
                    card.OnViewDetailsClicked += (s, ev) =>
                    {
                        MessageBox.Show($"Details:\nItem: {newItem.ItemName}\nLocation: {newItem.Location}\nDescription: {newItem.Description}",
                                        "Item Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };

                    card.OnClaimClicked += (s, ev) =>
                    {
                        DialogResult result = MessageBox.Show($"Mark '{newItem.ItemName}' as claimed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            flowLayoutPanel1.Controls.Remove(card);
                            MessageBox.Show("Item successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    };

                    // Idadagdag sa FlowLayoutPanel mo
                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }
    }
}
