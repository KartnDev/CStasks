using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumMethods1
{
    public partial class Form1 : Form
    {

        static double InterpolateLagrangePolynomial (double x, double[] xValues, double[] yValues, int size)
        {
            double lagrangePol = 0;
 
            for (int i = 0; i < size; i++)
            {
                    double basicsPol = 1;
                    for (int j = 0; j < size; j++)
                    {
                        if (j != i)
                        {
                            basicsPol *= (x - xValues[j])/(xValues[i] - xValues[j]);
                        }
                    }
                    lagrangePol += basicsPol * yValues[i];
            }
 
            return lagrangePol;
        }
 

        public double Newton(double x, int n, double[] MasX, double[] MasY, double step)
        {
            double[,] mas = new double[n + 2, n + 1];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0)
                        mas[i, j] = MasX[j];
                    else if (i == 1)
                        mas[i, j] = MasY[j];
                }
            }
            int m = n;
            for (int i = 2; i < n + 2; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = mas[i - 1, j + 1] - mas[i - 1, j];
                }
                m--;
            }

            double[] dy0 = new double[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                dy0[i] = mas[i + 1, 0];
            }

            double res = dy0[0];
            double[] xn = new double[n];
           xn[0] = x - mas[0, 0];

            for (int i = 1; i < n; i++)
            {
                double ans = xn[i - 1] * (x - mas[0, i]);
                xn[i] = ans;
                ans = 0;
            }

            int m1 = n + 1;
            int fact = 1;
            for (int i = 1; i < m1; i++)
            {
                fact = fact * i;
                res = res + (dy0[i] * xn[i - 1]) / (fact * Math.Pow(step, i));
            }

            return res;
        }




        private delegate float LambdaFunc(double argX);

        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            graphics = canvasBox.CreateGraphics();
            
        }

        private void DrawFunction(LambdaFunc func, Color color)
        {
            for (double i = 20; i < canvasBox.Width - 20; i += 1)
            {
                graphics.DrawLine(new Pen(color, 2), (float)i, canvasBox.Height - func(i), (float)(i + 1), canvasBox.Height - func(i + 1));
            }
        }

        private void RenderButtonOnClick(object sender, EventArgs e)
        {
            DrawFunction((x) => (float)(50* Math.Sin(x/100) + 100), Color.Black);

            double[] MasX = new double[] { 0, Math.PI/2, Math.PI, Math.PI*3/2, Math.PI *2 };
            double[] MasY = new double[] { Math.Sin(MasX[0]), Math.Sin(MasX[1]), Math.Sin(MasX[2]), Math.Sin(MasX[3]), Math.Sin(MasX[4]) };
            int n = 4;
            DrawFunction((x) => (float)(50*Newton(x/100, n, MasX, MasY, 1.6) +100), Color.Red);
        }
    }
}
