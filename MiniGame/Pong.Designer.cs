
namespace MiniGame
{
    partial class Pong
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
            this.player = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.cpu = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.playerScoreForm = new System.Windows.Forms.Label();
            this.cpuScoreForm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Blue;
            this.player.Location = new System.Drawing.Point(12, 200);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(30, 100);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Red;
            this.ball.Location = new System.Drawing.Point(283, 247);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(30, 30);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // cpu
            // 
            this.cpu.BackColor = System.Drawing.SystemColors.Info;
            this.cpu.Location = new System.Drawing.Point(542, 200);
            this.cpu.Name = "cpu";
            this.cpu.Size = new System.Drawing.Size(30, 100);
            this.cpu.TabIndex = 2;
            this.cpu.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 2;
            this.gameTimer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // playerScoreForm
            // 
            this.playerScoreForm.AutoSize = true;
            this.playerScoreForm.Font = new System.Drawing.Font("Wide Latin", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScoreForm.ForeColor = System.Drawing.Color.Blue;
            this.playerScoreForm.Location = new System.Drawing.Point(12, 9);
            this.playerScoreForm.Name = "playerScoreForm";
            this.playerScoreForm.Size = new System.Drawing.Size(122, 50);
            this.playerScoreForm.TabIndex = 3;
            this.playerScoreForm.Text = "00";
            // 
            // cpuScoreForm
            // 
            this.cpuScoreForm.AutoSize = true;
            this.cpuScoreForm.Font = new System.Drawing.Font("Wide Latin", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuScoreForm.ForeColor = System.Drawing.SystemColors.Info;
            this.cpuScoreForm.Location = new System.Drawing.Point(450, 9);
            this.cpuScoreForm.Name = "cpuScoreForm";
            this.cpuScoreForm.Size = new System.Drawing.Size(122, 50);
            this.cpuScoreForm.TabIndex = 4;
            this.cpuScoreForm.Text = "00";
            // 
            // Pong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.cpuScoreForm);
            this.Controls.Add(this.playerScoreForm);
            this.Controls.Add(this.cpu);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.player);
            this.Name = "Pong";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox cpu;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label playerScoreForm;
        private System.Windows.Forms.Label cpuScoreForm;
    }
}

