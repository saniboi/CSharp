using System;
using System.Windows.Forms;

namespace MiniGame
{
    public partial class Pong : Form
    {
        private bool moveUp;
        private bool moveDown;
        private int speed = 5;
        private int speedIncrement = 1;
        private const int Difficulty = 3;
        private const int MaxScore = 10;
        private int ballPositionX = 5;
        private int ballPositionY = 5;
        private int playerScore; 
        private int cpuScore;


        public Pong()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                moveUp = true;
            }
            if (e.KeyCode == Keys.S)
            {
                moveDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.S)
            {
                moveDown = false;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            SetScore();
            MovePlayer();
            SetBallPosition();
            UpdateCpuBrain();
            CheckForScore();
            CheckBallBorderCollision();
            CheckBallPlayerCollision();
            CheckGameEnd();
        }

        private void CheckGameEnd()
        {
            if (playerScore > MaxScore)
            {
                gameTimer.Stop();
                MessageBox.Show("You are the winner!");
            }
            if (cpuScore > MaxScore)
            {
                gameTimer.Stop();
                MessageBox.Show("You lost!");
            }
        }

        private void MovePlayer()
        {
            if (moveUp && player.Top > 0)
            {
                player.Top -= 8;
            }

            if (moveDown && player.Top < ClientSize.Height - player.Height)
            {
                player.Top += 8;
            }
        }

        private void CheckBallPlayerCollision()
        {
            if (ball.Bounds.IntersectsWith(player.Bounds) || ball.Bounds.IntersectsWith(cpu.Bounds))
            {
                ballPositionX = -ballPositionX;
            }
        }

        private void CheckBallBorderCollision()
        {
            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                ballPositionY = -ballPositionY;
            }
        }

        private void CheckForScore()
        {
            CheckCpuScored();

            CheckPlayerScored();
        }

        private void CheckPlayerScored()
        {
            if (ball.Left + ball.Width > ClientSize.Width)
            {
                ball.Left = ClientSize.Width - (ClientSize.Width / 3);
                ballPositionX = -ballPositionX;
                ballPositionX += speedIncrement;
                playerScore++;
            }
        }

        private void CheckCpuScored()
        {
            if (ball.Left < 0)
            {
                ball.Left = ClientSize.Width / 3;
                ballPositionX = -ballPositionX;
                ballPositionX -= speedIncrement;
                cpuScore++;
            }
        }

        private void UpdateCpuBrain()
        {
            UpdateCpuSpeed();

            UpdateCpuBehaviour();

            
        }

        private void UpdateCpuBehaviour()
        {
            if (playerScore < cpuScore + Difficulty)
            {
                EasyBehaviour();
            }
            else
            {
                DifficultBehaviour();
            }
        }

        private void DifficultBehaviour()
        {
            cpu.Top = ball.Top + 20;
        }

        private void EasyBehaviour()
        {
            if (cpu.Top < 0 || cpu.Top > ClientSize.Height - cpu.Height)
            {
                speed = -speed;
            }
        }

        private void UpdateCpuSpeed()
        {
            cpu.Top += speed;
        }

        private void SetBallPosition()
        {
            ball.Left -= ballPositionX;
            ball.Top -= ballPositionY;
        }

        private void SetScore()
        {
            playerScoreForm.Text = playerScore.ToString();
            cpuScoreForm.Text = "" + cpuScore;
        }
    }
}
