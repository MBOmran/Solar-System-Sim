
namespace Solar_System_Sim
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.leftmovetimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.minbtn = new System.Windows.Forms.Button();
            this.winbtn = new System.Windows.Forms.Button();
            this.clsbtn = new System.Windows.Forms.Button();
            this.player = new System.Windows.Forms.PictureBox();
            this.rightmovetimer = new System.Windows.Forms.Timer(this.components);
            this.upmovetimer = new System.Windows.Forms.Timer(this.components);
            this.downmovetimer = new System.Windows.Forms.Timer(this.components);
            this.bullet = new System.Windows.Forms.Timer(this.components);
            this.enemymove = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // leftmovetimer
            // 
            this.leftmovetimer.Interval = 5;
            this.leftmovetimer.Tick += new System.EventHandler(this.leftmovetimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(18)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.minbtn);
            this.panel1.Controls.Add(this.winbtn);
            this.panel1.Controls.Add(this.clsbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 27);
            this.panel1.TabIndex = 1;
            // 
            // minbtn
            // 
            this.minbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(48)))), ((int)(((byte)(83)))));
            this.minbtn.BackgroundImage = global::Solar_System_Sim.Properties.Resources.icons8_minimize_window_80;
            this.minbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minbtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minbtn.FlatAppearance.BorderSize = 0;
            this.minbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minbtn.Location = new System.Drawing.Point(713, 0);
            this.minbtn.Name = "minbtn";
            this.minbtn.Size = new System.Drawing.Size(29, 27);
            this.minbtn.TabIndex = 2;
            this.minbtn.UseVisualStyleBackColor = false;
            this.minbtn.Click += new System.EventHandler(this.minbtn_Click_1);
            // 
            // winbtn
            // 
            this.winbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(48)))), ((int)(((byte)(83)))));
            this.winbtn.BackgroundImage = global::Solar_System_Sim.Properties.Resources.icons8_restore_window_80;
            this.winbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.winbtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.winbtn.FlatAppearance.BorderSize = 0;
            this.winbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winbtn.Location = new System.Drawing.Point(742, 0);
            this.winbtn.Name = "winbtn";
            this.winbtn.Size = new System.Drawing.Size(29, 27);
            this.winbtn.TabIndex = 1;
            this.winbtn.UseVisualStyleBackColor = false;
            this.winbtn.Click += new System.EventHandler(this.winbtn_Click_1);
            // 
            // clsbtn
            // 
            this.clsbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(48)))), ((int)(((byte)(83)))));
            this.clsbtn.BackgroundImage = global::Solar_System_Sim.Properties.Resources.icons8_no_80;
            this.clsbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clsbtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.clsbtn.FlatAppearance.BorderSize = 0;
            this.clsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clsbtn.Location = new System.Drawing.Point(771, 0);
            this.clsbtn.Name = "clsbtn";
            this.clsbtn.Size = new System.Drawing.Size(29, 27);
            this.clsbtn.TabIndex = 0;
            this.clsbtn.UseVisualStyleBackColor = false;
            this.clsbtn.Click += new System.EventHandler(this.clsbtn_Click_1);
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::Solar_System_Sim.Properties.Resources.icons8_spaceship_24;
            this.player.InitialImage = global::Solar_System_Sim.Properties.Resources.icons8_spaceship_24;
            this.player.Location = new System.Drawing.Point(380, 399);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(43, 39);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.player.TabIndex = 2;
            this.player.TabStop = false;
            // 
            // rightmovetimer
            // 
            this.rightmovetimer.Interval = 5;
            this.rightmovetimer.Tick += new System.EventHandler(this.rightmovetimer_Tick);
            // 
            // upmovetimer
            // 
            this.upmovetimer.Interval = 5;
            this.upmovetimer.Tick += new System.EventHandler(this.upmovetimer_Tick);
            // 
            // downmovetimer
            // 
            this.downmovetimer.Interval = 5;
            this.downmovetimer.Tick += new System.EventHandler(this.downmovetimer_Tick);
            // 
            // bullet
            // 
            this.bullet.Enabled = true;
            this.bullet.Interval = 20;
            this.bullet.Tick += new System.EventHandler(this.bullet_Tick);
            // 
            // enemymove
            // 
            this.enemymove.Enabled = true;
            this.enemymove.Tick += new System.EventHandler(this.enemymove_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(133, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(530, 128);
            this.label1.TabIndex = 3;
            this.label1.Text = "Game Over";
            this.label1.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form2";
            this.Text = "Form2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer leftmovetimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button minbtn;
        private System.Windows.Forms.Button winbtn;
        private System.Windows.Forms.Button clsbtn;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer rightmovetimer;
        private System.Windows.Forms.Timer upmovetimer;
        private System.Windows.Forms.Timer downmovetimer;
        private System.Windows.Forms.Timer bullet;
        private System.Windows.Forms.Timer enemymove;
        private System.Windows.Forms.Label label1;
    }
}