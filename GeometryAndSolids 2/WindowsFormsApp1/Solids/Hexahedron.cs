using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Solids
{

    public class Hexahedron : BasePlatonicSolid, ISolid
    {

        public Hexahedron(int centerPlateOfX, int centerPlateOfY, int centerPlateOfZ, int imaginaryRadius)
                : base(centerPlateOfX, centerPlateOfY, centerPlateOfZ, imaginaryRadius)
        {

            matrix = new double[8,3];


            for (double teta = 0, i = 0; teta < Math.PI * 2; teta += Math.PI / 2, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + imaginaryRadius * Math.Cos(teta);
                matrix[(int)i, 1] = centerPlateOfY + imaginaryRadius * Math.Sin(teta);
                matrix[(int)i, 2] = centerPlateOfZ;
                matrix[(int)i + 4, 0] = centerPlateOfX + imaginaryRadius * Math.Cos(teta);
                matrix[(int)i + 4, 1] = centerPlateOfY + imaginaryRadius * Math.Sin(teta);
                matrix[(int)i + 4, 2] = centerPlateOfX + Math.Sqrt(2) * imaginaryRadius;
            }
        }

        public override void DrawSolid(Graphics g, double coef, double alpha)
        {
            var points = this.ToPointArray(coef, alpha);


            for (int i = 0; i < (int)(points.GetLength(0) / 2 - 1); i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }
            for (int i = 0; i < (int)(points.GetLength(0) / 2 - 1); i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 4].X, points[i + 4].Y);
            }
            for (int i = 4; i < (int)(points.GetLength(0) / 2) + 3; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }
            g.DrawLine(Pens.Aqua, points[0].X, points[0].Y, points[3].X, points[3].Y);
            g.DrawLine(Pens.Aqua, points[3].X, points[3].Y, points[7].X, points[7].Y);
            g.DrawLine(Pens.Aqua, points[4].X, points[4].Y, points[7].X, points[7].Y);
        }

    }
}

