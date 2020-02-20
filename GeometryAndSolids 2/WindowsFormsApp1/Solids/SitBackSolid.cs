using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Solids
{
    class SitBackSolid : BasePlatonicSolid
    {

        private Pen solidPen = new Pen(new SolidBrush(Color.Blue), 2);

        public SitBackSolid(double height) : base(0, 0, 0, 0)
        {
            matrix = new double[8, 3];
            matrix[0, 0] = 0; matrix[0, 1] = 0; matrix[0, 2] = 50;
            matrix[1, 0] = 50; matrix[1, 1] = 0; matrix[1, 2] = 50;
            matrix[2, 0] = 50; matrix[2, 1] = 10; matrix[2, 2] = 50;
            matrix[3, 0] = 0; matrix[3, 1] = 10; matrix[3, 2] = 50;

            matrix[4, 0] = 0; matrix[4, 1] = 0; matrix[4, 2] = 50 + height;
            matrix[5, 0] = 50; matrix[5, 1] = 0; matrix[5, 2] = 50 + height;
            matrix[6, 0] = 50; matrix[6, 1] = 10; matrix[6, 2] = 50 + height;
            matrix[7, 0] = 0; matrix[7, 1] = 10; matrix[7, 2] = 50 + height;
        }

        public override void DrawSolid(Graphics g, double coef, double alpha)
        {
            var points = this.ToPointArray(coef, alpha);


            for (int i = 0; i < (int)(points.GetLength(0) / 2 - 1); i++)
            {
                g.DrawLine(solidPen, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }
            for (int i = 0; i < (int)(points.GetLength(0) / 2 - 1); i++)
            {
                g.DrawLine(solidPen, points[i].X, points[i].Y, points[i + 4].X, points[i + 4].Y);
            }
            for (int i = 4; i < (int)(points.GetLength(0) / 2) + 3; i++)
            {
                g.DrawLine(solidPen, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }
            g.DrawLine(solidPen, points[0].X, points[0].Y, points[3].X, points[3].Y);
            g.DrawLine(solidPen, points[3].X, points[3].Y, points[7].X, points[7].Y);
            g.DrawLine(solidPen, points[4].X, points[4].Y, points[7].X, points[7].Y);
        }
    }
}
