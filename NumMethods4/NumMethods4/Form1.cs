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
        static double dydx(double x, double y)
        {
            return x / y;
        }

        // Finds value of y for a given x 
        // using step size h and initial 
        // value y0 at x0. 
        static double rungeKutta(double x0, double y0, double x, double h)
        {

            // Count number of iterations using 
            // step size or step height h 
            int n = (int)((x - x0) / h);

            double k1, k2, k3, k4;

            // Iterate for number of iterations 
            double y = y0;

            for (int i = 1; i <= n; i++)
            {

                // Apply Runge Kutta Formulas 
                // to find next value of y 
                k1 = h * (dydx(x0, y));

                k2 = h * (dydx(x0 + 0.5 * h,
                         y + 0.5 * k1));

                k3 = h * (dydx(x0 + 0.5 * h,
                         y + 0.5 * k2));

                k4 = h * (dydx(x0 + h, y + k3));

                // Update next value of y 
                y = y + (1.0 / 6.0) * (k1 + 2
                                       * k2 + 2 * k3 + k4);

                // Update next value of x 
                x0 = x0 + h;
            }

            return y;
        }



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
            new Task(() => {
            DrawFunction((x) => (float)(1/x), Color.Black); // График
            Task.Delay(100);
            DrawFunction((x) => 2 + (float)DiffMethods.Adams(0, 1, x, 0.1), Color.Brown);
            Task.Delay(100);
            DrawFunction((x) => 4 + (float) DiffMethods.EulerCounting(0, 1, x, 0.1), Color.Aqua);
            Task.Delay(100);
            DrawFunction((x) => 6 +(float)DiffMethods.RungeKutta(0, 1, x, 0.1), Color.Blue);
            Task.Delay(100);
            DrawFunction((x) => 8 + (float)DiffMethods.ModifiedEuler(0, 1, x, 0.1), Color.DarkMagenta);
            Task.Delay(100);
            }).Start();
            
        }
    }
}
