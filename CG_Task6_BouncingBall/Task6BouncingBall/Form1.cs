using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6BouncingBall
{
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private bool running = true;

        private int dx = 0, dy = 0;
        private int dsteps = 0;

        private int ballSpeedX = 10, ballSpeedY = 10;
        private Rectangle ballRectangle = new Rectangle(300, 300, 40, 40);

        public Form1()
        {
            InitializeComponent();
            _graphics = pictureBox1.CreateGraphics();
        }
        private void Clear()
        {
            _graphics.Clear(this.BackColor);
        }
        private async void Draw()
        {
            while (running)
            {
                Clear();
                // Draw Borders
                _graphics.FillRectangle(Brushes.Red, 0, 0, 10, pictureBox1.Height);
                _graphics.FillRectangle(Brushes.Red, 0, 0, pictureBox1.Width, 10);
                _graphics.FillRectangle(Brushes.Red, 0, pictureBox1.Height - 10, pictureBox1.Width, pictureBox1.Height);
                _graphics.FillRectangle(Brushes.Red, pictureBox1.Width - 10, 0, pictureBox1.Width, pictureBox1.Height);
                // Draw Ball
                _graphics.FillEllipse(Brushes.Blue, ballRectangle);

                HandleBallCoordinates();

                


                await Task.Delay(200);
            }
        }

        private void PlayButtonClick(object sender, EventArgs e)
        {
            Draw();
        }



        private void HandleBallCoordinates()
        {

            ballRectangle.X += ballSpeedX;
            ballRectangle.Y += ballSpeedY;

            if (dsteps != 0)
            {
                ballRectangle.Width += dx;
                ballRectangle.Height += dy;
                dsteps--;
            }

            if (ballRectangle.IntersectsWith(new Rectangle(0, 0, 10, pictureBox1.Height)))
            {
                ballSpeedX *= -1;
                dx = -2;
                dy = 2;
                dsteps = 5;
            }
            if (ballRectangle.IntersectsWith(new Rectangle(0, 0, pictureBox1.Width, 10)))
            {
                ballSpeedY *= -1;
                dx = 2;
                dy = -2;
                dsteps = 5;
            }
            if (ballRectangle.IntersectsWith(new Rectangle(0, pictureBox1.Height - 10, pictureBox1.Width, pictureBox1.Height)))
            {
                ballSpeedY *= -1;
                dx = 2;
                dy = -2;
                dsteps =5;
            }
            if (ballRectangle.IntersectsWith(new Rectangle(pictureBox1.Width - 10, 0, pictureBox1.Width, pictureBox1.Height)))
            {
                ballSpeedX *= -1;
                dx = 2;
                dy = -2;
                dsteps = 5;
            }

            if(dsteps == 0 && (ballRectangle.Width != 40 || ballRectangle.Height != 40))
            {
                dsteps = 5;
                dx *= -1;
                dy *= -1;
            }

        }

    }
}
