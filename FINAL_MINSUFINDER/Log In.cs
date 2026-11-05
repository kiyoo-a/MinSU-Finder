using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_MINSUFINDER
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            RoundButton(btnLogIn, 35);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();

        }
        private void RoundButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);

            path.CloseFigure();

            btn.Region = new Region(path);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var registerForm = new Register())
            {
                registerForm.ShowDialog(this);
            }

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
