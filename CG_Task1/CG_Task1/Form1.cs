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

namespace CG_Task1
{
    public partial class Form1 : Form
    {

        private Rectangle leftBorder, rightBorder, topBorder, bottomBorder;
        private int ballSpeedX = 5, ballSpeedY = 5;


        public Form1()
        {
            InitializeComponent();
        }

        private class Ball
        {

            public Rectangle rectangleEntity;
            public Ball(int startupX, int startupY, int radius)
            {
                rectangleEntity = new Rectangle(startupX, startupY, radius * 2, radius * 2);
            }
        }
        private void fillBorders(Graphics g, int marginLeft, int marginTop, int marginRight, int margineBottem)
        {

            leftBorder = new Rectangle(0, 0, marginLeft, Height);
            topBorder = new Rectangle(0, 0, Width, marginTop);
            rightBorder = new Rectangle((int)(Width - marginRight * 1.7), 0, marginRight, Height);
            bottomBorder = new Rectangle(0, (int)(Height - margineBottem * 2.8), Width, margineBottem);

            SolidBrush borderBrush = new SolidBrush(Color.Black);
            // filling left border
            g.FillRectangle(borderBrush, leftBorder);
            // fill top border 
            g.FillRectangle(borderBrush, topBorder);
            // fill right border
            g.FillRectangle(borderBrush, rightBorder);
            // fill bottom border
            g.FillRectangle(borderBrush, bottomBorder);

        }

        private void ClearTable(Graphics g)
        {
            g.Clear(Color.White);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            ClearTable(e.Graphics);
            Ball ball1 = new Ball(140, 55, 10);

            while (true)
            {
                fillBorders(e.Graphics, 20, 20, 20, 20);

                e.Graphics.FillEllipse(new SolidBrush(Color.Aqua), ball1.rectangleEntity.X, ball1.rectangleEntity.Y, ball1.rectangleEntity.Width, ball1.rectangleEntity.Height);
                Thread.Sleep(50);
                ball1.rectangleEntity.X += ballSpeedX;
                ball1.rectangleEntity.Y += ballSpeedY;

                if (ball1.rectangleEntity.IntersectsWith(rightBorder))
                {
                    ballSpeedX = -5;
                }
                if (ball1.rectangleEntity.IntersectsWith(bottomBorder))
                {
                    ballSpeedY = -5;
                }
                if(ball1.rectangleEntity.IntersectsWith(topBorder))
                {
                    ballSpeedY = +5;
                }
                if(ball1.rectangleEntity.IntersectsWith(leftBorder))
                {
                    ballSpeedX = +5;
                }

                ClearTable(e.Graphics);


            }





        }
    }
}
