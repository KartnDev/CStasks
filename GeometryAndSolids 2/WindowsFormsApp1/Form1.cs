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
            //var leftChairLeg = new Hexahedron(0, 0, 0, 30);
            //leftChairLeg.Scale(1, 1, 5);
            //leftChairLeg.RotateByX(Math.PI / 2);
            //leftChairLeg.Shift(100, 300, 200);
            //leftChairLeg.DrawSolid(graphics, 0.6, Math.PI / 4);
            //var leftChairLeg3 = new Hexahedron(0, 0, 0, 30);
            //leftChairLeg3.Scale(1, 1, 5);
            //leftChairLeg3.RotateByX(Math.PI / 2);
            //leftChairLeg3.Shift(200, 300, 100);
            //leftChairLeg3.DrawSolid(graphics, 0.6, Math.PI / 4);
            //var leftChairLeg1 = new Hexahedron(0, 0, 0, 30);
            //leftChairLeg1.Scale(1, 1, 5);
            //leftChairLeg1.RotateByX(Math.PI / 2);
            //leftChairLeg1.Shift(300, 300, 200);
            //leftChairLeg1.DrawSolid(graphics, 0.6, Math.PI / 4);
            //var leftChairLeg2 = new Hexahedron(0, 0, 0, 30);
            //leftChairLeg2.Scale(1, 1, 5);
            //leftChairLeg2.RotateByX(Math.PI / 2);
            //leftChairLeg2.Shift(200, 300, 300);
            //leftChairLeg2.DrawSolid(graphics, 0.6, Math.PI / 4);
            //var flat = new Hexahedron(0, 0, 0, 100);
            //flat.Scale(1, 1, 1);
            //flat.RotateByX(Math.PI / 2);
            //flat.Shift(160, 221, 200);
            //flat.DrawSolid(graphics, 0.6, Math.PI / 4);
            var delta = 1.0;

            while (renderFlag)
            {
                graphics.Clear(pictureBox1.BackColor);
                var chair = new ChairSolid();
                chair.Scale(3, 3, 3);
                chair.RotateByX(Math.PI / 2);
                chair.Scale(delta, 1, 1);
                if (delta < 2.5)
                {
                    delta += 0.01;
                }
                chair.Shift(100, 200, 200);
                chair.DrawSolid(graphics, 0.6, Math.PI / 4);
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
