using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace Solar_System_Sim
{
    public partial class Form1 : Form
    {
        bool sidebarExpanded = true;
        bool solarclicked = true; //to only open browser when solar btn clicked not menu
        private bool isAnimating = false; // only show/hide browser after menu change done
        private Dictionary<string, Image> celestialBodyImages;
        float earthOrbitalVelocity = 0.01f; // Earth's orbital velocity (adjust as needed)
        float px = 470, py = 300;
        float distanceScale = 72; // Scale factor for distances
        float timeScale = 0.5f; // Scale factor for time
        float angle = 0;
        public static WebView2 mybrowser; // for my wirtual browser // 27/12/2023
        public static string htmlContent; // will be specific For Every Page..
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.MouseClick += Form1_MouseClick; // intended for implementing on planet click in future
        }
        #region Menu Handling
        private void HideMenu(Timer timer)
        {
            timer.Start();
            if (sidebarExpanded)
            {
                sidebar.Width -= 5;
                Infobar.Width -= 9;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpanded = false;
                    // hide the controls on sidebars
                    ToggleControls(sidebarExpanded);
                    timer.Stop();
                }
            }
            else
            {
                sidebar.Width += 5;
                Infobar.Width += 9;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpanded = true;
                    // show the controls on sidebars
                    ToggleControls(sidebarExpanded);
                    timer.Stop();
                }
            }
        }
        private void ToggleControls(bool Expanded)
        {
            if (Expanded)
            {
                label10.Show();
                label11.Show();
                trackBar1.Show();
                trackBar2.Show();
                button1.Show();
            }
            else
            {
                label10.Hide();
                label11.Hide();
                trackBar1.Hide();
                trackBar2.Hide();
                button1.Hide();
            }
        }
        private void menubtn_Click(object sender, EventArgs e)
        {
            HideMenu(sidebarTimer);
        }
        #endregion
        public static void InitializeMyBrowser()
        {
            mybrowser = new WebView2();
            mybrowser.Dock = DockStyle.Fill;
            try
            {
                mybrowser.CoreWebView2InitializationCompleted += WebView2_CoreWebView2InitializationCompleted;
                mybrowser.EnsureCoreWebView2Async();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Solar System Button
        private void Solarsystembtn_Click(object sender, System.EventArgs e)
        {
            if (!isAnimating)  //to make sure we only show / hide browser after menu change done
            {
                Planetorbit.Stop();
                isAnimating = true;
                SolarSystemTimer.Start();
            }
        }
        private void ToggleBrowserAndButtons(bool show) // just to make code more readable.
        {
            if (show)
            {
                button2.Hide();
                button3.Hide();
                Controls.Add(mybrowser);
            }
            else
            {
                button2.Show();
                button3.Show();
                Controls.Remove(mybrowser);
            }
        }
        
        private void SolarSystemTimer_Tick(object sender, System.EventArgs e)
        {
            if (sidebarExpanded) HideMenu(SolarSystemTimer); //only menus when necessary
            if (sidebar.Width == sidebar.MinimumSize.Width || sidebar.Width == sidebar.MaximumSize.Width)
            {
                SolarSystemTimer.Stop();
                isAnimating = false;
                ToggleBrowserAndButtons(solarclicked);
                solarclicked = !solarclicked;
            }
        }
        #endregion 
        #region Drawing Celestial Bodies
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            StringFormat str = new StringFormat();

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the Sun
            DrawCelestialBody(g, "Sun", earthOrbitalVelocity, distanceScale * 1.25f, timeScale, Color.Yellow, str);
            // Draw the planets and their moons
            DrawCelestialBody(g, "Earth", 1.000f * earthOrbitalVelocity, distanceScale * 1.25f, timeScale,null,null,"Moon");//we could overload
            DrawCelestialBody(g, "Mercury", 4.150f * earthOrbitalVelocity, distanceScale * 0.40f, timeScale); 
            DrawCelestialBody(g, "Venus", 1.620f * earthOrbitalVelocity, distanceScale * 0.90f, timeScale);
            DrawCelestialBody(g, "Mars", 0.260f * earthOrbitalVelocity, distanceScale * 1.70f, timeScale);
            DrawCelestialBody(g, "Jupiter", 0.080f * earthOrbitalVelocity, distanceScale * 4.5f, timeScale);
            DrawCelestialBody(g, "Saturn", 0.030f * earthOrbitalVelocity, distanceScale * 8.0f, timeScale);
            DrawCelestialBody(g, "Uranus", 0.010f * earthOrbitalVelocity, distanceScale * 10.0f, timeScale);
            DrawCelestialBody(g, "Neptune", 0.005f * earthOrbitalVelocity, distanceScale * 11.8f, timeScale);
            // ... (We can continue to add moons or other celestial bodies as needed)
        }
        private void DrawCelestialBody(Graphics g, string bodyName, float orbitalVelocity, float orbitRadius, float timeScale, Color? labelColor = null, StringFormat labelFormat = null, string MoonName = null)
        {
            float bodyAngle = angle * orbitalVelocity * timeScale;
            int x = (int)(px + orbitRadius * Math.Cos(bodyAngle) - celestialBodyImages[bodyName].Width / 2);
            int y = (int)(py + orbitRadius * Math.Sin(bodyAngle) - celestialBodyImages[bodyName].Height / 2);

            g.DrawEllipse(Pens.White, px - orbitRadius, py - orbitRadius, 2 * orbitRadius, 2 * orbitRadius);

            // Special handling for the Sun
            if (bodyName == "Sun")
            {
                g.DrawImage(celestialBodyImages[bodyName], px - 18, py - 18);
                if (labelColor.HasValue && labelFormat != null)
                {
                    g.DrawString(bodyName, Font, new SolidBrush(labelColor.Value), px - 35, py - 5, labelFormat);
                }
            }
            else
            {
                // Draw the celestial body image
                try
                {
                    g.DrawImage(celestialBodyImages[bodyName], x, y);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error drawing {bodyName} image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if(MoonName != null)
                {
                    try
                    {
                        float moonAngle = angle * 12.5f * orbitalVelocity * timeScale; // Moon's orbital velocity
                        int moonX = (int)(x + 30 * Math.Cos(moonAngle));
                        int moonY = (int)(y + 30 * Math.Sin(moonAngle));
                        g.DrawImage(celestialBodyImages[MoonName], moonX+10, moonY+10);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Error drawing Moon image: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Draw the celestial body label
                if (labelColor.HasValue && labelFormat != null)
                {
                    g.DrawString(bodyName, Font, new SolidBrush(labelColor.Value), x - 35, y - 5, labelFormat);
                }
            }
        }
        #endregion
        private void Planetorbit_Tick(object sender, EventArgs e)
        {
            angle += 1.0f; // Adjust the time increment for the planets
            Invalidate();
        }

        #region Buttons
        private void button2_Click(object sender, EventArgs e) //Start Button
        {
            Planetorbit.Start();
        }

        private void button3_Click(object sender, EventArgs e) //Stop Button
        {
            Planetorbit.Stop();
        }
        private void clsbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void satelitebtn_Click(object sender, EventArgs e) //Game
        {
            ShowForm<Form2>();
        }
        private void winbtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;

            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }
        #endregion
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //still not used , was intended for on-planet click
        }

        #region Planet Forms
        private void ShowForm<T>() where T : Form, new()  //after seeing that we will repeat this task alot
        {                                                 //decided to write a method to do it for me.
            Planetorbit.Stop();
            Form newForm = new T();
            this.Hide();
            newForm.Show();
            newForm.FormClosed += (sender, e) => this.Show();
        }
        // opening Planet Forms...
        private void objpic_Click(object sender, EventArgs e)
        {
            ShowForm<EarthForm>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowForm<MercuryForm>();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShowForm<VenusForm>();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowForm<MarsForm>();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ShowForm<JupiterForm>();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ShowForm<SaturnForm>();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ShowForm<UranusForm>();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ShowForm<NeptuneForm>();
            

        }
        #endregion
        #region TrackBars
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            distanceScale = trackBar1.Value;
            Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int minValue = 1;
            int maxValue = 20;

            // Map the trackBar2 values to a suitable range for timeScale (ex.., 0.1 to 2.0)
            timeScale = 0.1f + 0.8f * (trackBar2.Value - minValue) / (maxValue - minValue);
            Invalidate();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeMyBrowser();
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            celestialBodyImages = new Dictionary<string, Image>
            {
                { "Sun", Image.FromFile(@".\Resources\icons8-sun-36.png") },
                { "Earth", Image.FromFile(@".\Resources\icons8-earth.png") },
                { "Moon", Image.FromFile(@".\Resources\icons8-moon-12.png") },
                { "Mercury", Image.FromFile(@".\Resources\icons8-mercury.png") },
                { "Venus", Image.FromFile(@".\Resources\icons8-venus.png") },
                { "Mars", Image.FromFile(@".\Resources\icons8-mars.png") },
                { "Jupiter", Image.FromFile(@".\Resources\icons8-jupiter.png") },
                { "Saturn", Image.FromFile(@".\Resources\icons8-saturn.png") },
                { "Uranus", Image.FromFile(@".\Resources\icons8-uranus.png") },
                { "Neptune", Image.FromFile(@".\Resources\icons8-neptune.png")}
        // Add more celestial bodies as needed
            };  

        }
        private static void WebView2_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            // Check if initialization is successful
            if (e.IsSuccess)
            {
                // WebView2 is ready, now you can navigate
                htmlContent = @"
                <html>
                <head></head>
                <body>
                    <iframe src='https://eyes.nasa.gov/apps/solar-system/#/home?embed=true' width='100%' height='100%'></iframe>
                </body>
                </html>";

                // Navigate only after CoreWebView2 is initialized
                try
                {
                    mybrowser.NavigateToString(htmlContent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error navigating to content: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Handle initialization failure
                MessageBox.Show("WebView2 initialization failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://drive.google.com/file/d/1b3somRycJzRRBAzECwBbFeqAkoGJ6dxT/view?usp=sharing");
        }

        private void minbtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
