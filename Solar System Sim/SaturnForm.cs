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
    public partial class SaturnForm : Form
    {
        public SaturnForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void SaturnForm_Load(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.FromArgb(15, 22, 52);
            Button changeback = new Button();
            changeback.Location = new Point(240, 400);
            changeback.Size = new Size(280, 50);
            changeback.Text = "Realistic Planet Background";
            changeback.Click += Changeback_Click;
            changeback.BackColor = Color.FromArgb(15, 22, 52);
            changeback.ForeColor = Color.White;
            changeback.Cursor = Cursors.Hand;
            Controls.Add(changeback);
            Form1.htmlContent = @"
                <html>
                <head></head>
                <body>
                    <iframe src='https://eyes.nasa.gov/apps/solar-system/#/saturn?rate=440&embed=true' width='100%' height='100%'></iframe>
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

        private void Changeback_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.FromArgb(98, 50, 62);
            textBox1.BackColor = Color.FromArgb(98, 50, 62);
            BackColor = Color.FromArgb(98, 50, 62);
            this.BackgroundImage = Image.FromFile(@".\Resources\Saturn-Background-Realistic.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://science.nasa.gov/saturn/");
        }
    }
}
