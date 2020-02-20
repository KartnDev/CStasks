using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Solids;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private bool renderFlag = true;

        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
        }

        public async void RenderSolids()
        {
            var delta = 1.0;
            var backSit = 60.0;
            while (renderFlag)
            {
                graphics.Clear(pictureBox1.BackColor);
                var chair = new ChairSolid();
                chair.Scale(3, 3, 3);
                chair.RotateByX(Math.PI / 2);
                chair.Scale(delta, 1, 1);
                chair.Shift(100, 300, 200);
                chair.DrawSolid(graphics, 0.6, Math.PI / 4);
                if (backSit > 0)
                {
                    var back = new SitBackSolid(backSit);
                    back.Scale(3, 3, 3);
                    back.RotateByX(Math.PI / 2);
                    back.Scale(delta, 1, 1);
                    back.Shift(100, 300, 200);
                    back.DrawSolid(graphics, 0.6, Math.PI / 4);
                    backSit -= 0.4;
                }

                if (delta < 2.5)
                {
                    delta += 0.01;
                }
                await Task.Delay(100);
            }
        }


        private void RenderButton_Click(object sender, EventArgs e)
        {
            renderFlag = true;
            RenderSolids();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            renderFlag = false;
            graphics.Clear(pictureBox1.BackColor);
        }

    }
}
