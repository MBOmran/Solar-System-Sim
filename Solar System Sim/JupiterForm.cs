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
    public partial class JupiterForm : Form
    {
        public JupiterForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://science.nasa.gov/jupiter/facts/");
        }

        private void JupiterForm_Load(object sender, EventArgs e)
        {
            Form1.htmlContent = @"
                <html>
                <head></head>
                <body>
                    <iframe src='https://eyes.nasa.gov/apps/solar-system/#/jupiter?rate=440&embed=true' width='100%' height='100%'></iframe>
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
