using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            for (double i = 20; i < pictureBox1.Width - 20; i += 1)
            {
                _graphics.DrawLine(new Pen(color, 2), (float)i, pictureBox1.Height - func(i), (float)(i + 1), pictureBox1.Height - func(i + 1));
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
            var t1 = new Task(() =>
            {
                DrawFunction((x) => (float)(1 / x), Color.Black); // График

                DrawFunction((x) => 4 + (float)DiffMethods.Adams(0, 1, x, 2), Color.Brown);

                DrawFunction((x) => 8 + (float)DiffMethods.EulerCounting(0, 1, x, 0.1), Color.Aqua);

                DrawFunction((x) => 16 + (float)DiffMethods.RungeKutta(0, 1, x, 0.1), Color.Blue);

                DrawFunction((x) => 32 + (float)DiffMethods.ModifiedEuler(0, 1, x, 0.1), Color.DarkMagenta);

            });
            t1.Start();

        }
    }
}
