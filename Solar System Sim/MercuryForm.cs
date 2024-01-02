using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solar_System_Sim
{
    public partial class MercuryForm : Form
    {
        public MercuryForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Mercury_(planet)");
        }

        private void MercuryForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"./Resources\mercury-background.jpg");
            Form1.htmlContent = @"
                <html>
                <head></head>
                <body>
                    <iframe src='https://eyes.nasa.gov/apps/solar-system/#/mercury?rate=440&embed=true' width='100%' height='100%'></iframe>
                </body>
                </html>";

            // Navigate only after CoreWebView2 is initialized
            try
            {
                Form1.mybrowser.NavigateToString(Form1.htmlContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to content: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
