using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumMethods4
{
    public partial class Form1 : Form
    {
        public delegate float LambdaFunc(double argX);

        private void DrawFunction(LambdaFunc func, Color color)
        {
            new Task(() =>
            {
                for (double i = 20; i < pictureBox1.Width - 20; i += 1)
                {
                    _graphics.DrawLine(new Pen(color, 2), (float)i, pictureBox1.Height - func(i), (float)(i + 1), pictureBox1.Height - func(i + 1));
                    Task.Delay(1);
                }
            }).Start();
        }

        private void DrawFunction(LambdaFunc func)
        {
            for (double i = 20; i < pictureBox1.Width - 20; i += 3)
            {
                _graphics.DrawLine(Pens.BlueViolet, (float)i, pictureBox1.Height - func(i), (float)(i + 1), pictureBox1.Height - func(i + 1));
                Task.Delay(1);
            }
        }



        private readonly Graphics _graphics;
        public Form1()
        {
            InitializeComponent();
            _graphics = pictureBox1.CreateGraphics();
        }

        private void DrawButtonClick(object sender, EventArgs e)
        {
            _graphics.DrawLine(Pens.Black, 20, 40, 20, 425);
            _graphics.DrawLine(Pens.Black, 20, 425, 700, 425);
            DrawFunction((x) => (float)(53 * Math.Sin(x / 10) + 54));

            if (comboBox1.SelectedItem == "CountingEuler")
            {
                DrawFunction((x) => (float)DiffMethods.EulerCounting(0, 1, x, 0.1), Color.Aqua);
            }

            if (comboBox1.SelectedItem == "ModifiedEuler")
            {
                DrawFunction((x) => (float)DiffMethods.ModifiedEuler(0, 1, x, 0.1), Color.Salmon);
            }
            if (comboBox1.SelectedItem == "RungeKutta4th")
            {
                DrawFunction((x) => (float)DiffMethods.RungeKutta(0, 1, x, 0.1), Color.Blue);
            }
            if (comboBox1.SelectedItem == "Adams4th")
            {
                DrawFunction((x) => (float)DiffMethods.Adams(0, 1, x, 0.1), Color.Green);
            }

        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            this._graphics.Clear(pictureBox1.BackColor);
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X: " + e.X;
            label2.Text = "Y: " + e.Y;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X: " + e.X;
            label2.Text = "Y: " + e.Y;
        }

    }
}
