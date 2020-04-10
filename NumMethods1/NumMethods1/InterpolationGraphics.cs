using NumMethods1.InterpolationMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethods1
{
    public class InterpolationGraphics
    {
        Rectangle canvasBox;

        public delegate float LambdaFunc(double argX);

        private readonly Graphics graphics;
        public InterpolationGraphics(Graphics graphics, Rectangle canvasBox)
        {
            this.graphics = graphics;
            this.canvasBox = canvasBox;
        }

        private void DrawFunction(LambdaFunc func, Color color)
        {
            for (double i = 20; i < canvasBox.Width - 20; i += 1)
            {
                graphics.DrawLine(new Pen(color, 2), (float)i, canvasBox.Height - func(i), (float)(i + 1), canvasBox.Height - func(i + 1));
            }
        }

        public void DrawInterpolation(LambdaFunc func, float step)
        {
            DrawFunction((x) => (float)(50 * func(x / 100) + 100), 
                Color.Black);

            double[] pointsX = new double[] { 0, Math.PI / 2, Math.PI, Math.PI * 3 / 2, Math.PI * 2};
            double[] pointsY = new double[] { func(pointsX[0]), func(pointsX[1]), func(pointsX[2]), func(pointsX[3]), func(pointsX[4])};


           DrawFunction((x) => (float)(50 * NewtonMethod.Newton(x / 100, pointsX, pointsY, (float)step) + 100), Color.Red);

           DrawFunction((x) => (float)(50 * LagrangeMethod.Langrange(x / 100, pointsX, pointsY, (float)step - 0.6f) + 100), Color.Green);
            
        }
    }
}
