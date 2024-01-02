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
    public partial class Form2 : Form
    {
        int playerspeed;
        PictureBox[] bullets;
        PictureBox[] enemies;
        int enemyspeed;
        int bulletspeed;
        public Form2()
        {
            InitializeComponent();
            playerspeed = 4;
            bulletspeed = 20;
            enemyspeed = 8;
            enemies = new PictureBox[20];
            Image enemy = Image.FromFile(@".\Resources\icons8-satellite-24.png");
            bullets = new PictureBox[3];
            Image bullet = Image.FromFile(@".\Resources\icons8-bullet-12.png");
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();
                bullets[i].Image = bullet;
                bullets[i].BackColor = Color.Transparent;
                bullets[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(bullets[i]);
            }
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Image = enemy;
                enemies[i].BackColor = Color.Transparent;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Location = new Point((i + 1) * 100, -50);
                this.Controls.Add(enemies[i]);
            }
        }

        private void downmovetimer_Tick(object sender, EventArgs e)
        {
            if (player.Top < 400)
            {
                player.Top += playerspeed;
            }

        }

        private void upmovetimer_Tick(object sender, EventArgs e)
        {
            if (player.Top > 10)
            {
                player.Top -= playerspeed;
            }

        }

        private void rightmovetimer_Tick(object sender, EventArgs e)
        {
            if (player.Left < 750)
            {
                player.Left += playerspeed;
            }

        }

        private void leftmovetimer_Tick(object sender, EventArgs e)
        {
            if (player.Left > 50)
            {
                player.Left -= playerspeed;
            }
        }
        private void clsbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void winbtn_Click_1(object sender, EventArgs e)
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

        private void minbtn_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                rightmovetimer.Start();
            }
            else
            if (e.KeyCode == Keys.A)
            {
                leftmovetimer.Start();
            }
            else
            if (e.KeyCode == Keys.S)
            {
                downmovetimer.Start();
            }
            else
            if (e.KeyCode == Keys.W)
            {
                upmovetimer.Start();
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                rightmovetimer.Stop();
            }
            if (e.KeyCode == Keys.A)
            {
                leftmovetimer.Stop();
            }
            if (e.KeyCode == Keys.W)
            {
                upmovetimer.Stop();
            }
            if (e.KeyCode == Keys.S)
            {
                downmovetimer.Stop();
            }


        }

        private void bullet_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].Top > 0)
                {
                    bullets[i].Visible = true;
                    bullets[i].Top -= bulletspeed;
                }
                else
                {
                    bullets[i].Visible = false;
                    bullets[i].Location = new Point(player.Location.X + 20, player.Location.Y - i * 30);
                }
            }
            Collusion();

        }

        private void enemymove_Tick(object sender, EventArgs e)
        {
            Enemymove(enemies, enemyspeed);
        }
        private void Enemymove(PictureBox[] enemies, int speed)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Visible = true;
                enemies[i].Top += speed;
                if (enemies[i].Top > this.Height)
                {
                    enemies[i].Location = new Point((i + 1) * 100, -200);
                }
            }
        }
        private void Collusion()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (bullets[0].Bounds.IntersectsWith(enemies[i].Bounds) || bullets[1].Bounds.IntersectsWith(enemies[i].Bounds) || bullets[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    enemies[i].Location = new Point((i + 1) * 100, -200);
                }
                else if (player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    player.Visible = false;
                    label1.Visible = true;
                    bullet.Stop();
                    MessageBox.Show("You Died!");
                    this.Close();
                }
            }
        }
    }
}
