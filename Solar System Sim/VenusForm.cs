using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Solar_System_Sim
{
    public partial class VenusForm : Form
    {
        public VenusForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void VenusForm_Load(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.FromArgb(170, 123, 71);
            button1.BackColor = Color.FromArgb(170, 123, 71);
            Form1.htmlContent = @"
                <html>
                <head></head>
                <body>
                    <iframe src='https://eyes.nasa.gov/apps/solar-system/#/venus?rate=440&embed=true' width='100%' height='100%'></iframe>
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

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://science.nasa.gov/venus/facts/");
        }
    }
}
