using System;
using System.Drawing;
using System.Windows.Forms;
using FINAL_MINSUFINDER.Model;

namespace FINAL_MINSUFINDER.Views
{
    public partial class ItemCard : UserControl
    {
        public Item ItemData { get; private set; }

        public event EventHandler OnClaimClicked;
        public event EventHandler OnViewDetailsClicked;

        private PictureBox pbImage;
        private Label lblTitle;
        private Label lblDate;
        private Label lblLocation;
        private Button btnView;
        private Button btnClaim;

        public ItemCard()
        {
            InitializeComponent();
            BuildCardUI();
        }

        public ItemCard(Item item) : this()
        {
            ItemData = item;
            PopulateData();
        }

        private void PopulateData()
        {
            if (ItemData == null) return;

            lblTitle.Text = ItemData.ItemName;
            lblDate.Text = "📅 " + ItemData.DateFound.ToString("MMM dd, yyyy");
            lblLocation.Text = "📍 Found at " + ItemData.Location;

            if (!string.IsNullOrEmpty(ItemData.ImagePath) && System.IO.File.Exists(ItemData.ImagePath))
            {
                pbImage.Image = Image.FromFile(ItemData.ImagePath);
            }
        }

        private void BuildCardUI()
        {
            this.Size = new Size(180, 240);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(10);

            pbImage = new PictureBox
            {
                Size = new Size(160, 100),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.LightGray
            };

            lblTitle = new Label
            {
                Location = new Point(10, 115),
                Size = new Size(160, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };

            lblDate = new Label
            {
                Location = new Point(10, 135),
                Size = new Size(160, 18),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray
            };

            lblLocation = new Label
            {
                Location = new Point(10, 153),
                Size = new Size(160, 18),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray
            };

            btnView = new Button
            {
                Text = "View Details",
                Location = new Point(10, 175),
                Size = new Size(160, 25),
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnView.Click += (s, e) => OnViewDetailsClicked?.Invoke(this, EventArgs.Empty);

            btnClaim = new Button
            {
                Text = "Mark as Claimed",
                Location = new Point(10, 205),
                Size = new Size(160, 25),
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClaim.Click += (s, e) => OnClaimClicked?.Invoke(this, EventArgs.Empty);

            this.Controls.Add(pbImage);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblDate);
            this.Controls.Add(lblLocation);
            this.Controls.Add(btnView);
            this.Controls.Add(btnClaim);
        }
    }
}