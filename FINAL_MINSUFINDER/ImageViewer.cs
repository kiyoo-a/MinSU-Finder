using System;
using System.Drawing;
using System.Windows.Forms;

namespace FINAL_MINSUFINDER
{
    public partial class ImageViewer : Form
    {
        public ImageViewer(Image image)
        {
            InitializeComponent();

            this.Text = "Image Preview";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;

            PictureBox picture = new PictureBox();
            picture.Dock = DockStyle.Fill;
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Image = new Bitmap(image);

            this.Controls.Add(picture);
        }
    }
}