using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Solids
{
    public class Tetrahedron : BasePlatonicSolid, ISolid
    {

        public Tetrahedron(int centerPlateOfX, int centerPlateOfY, int centerPlateOfZ, int imaginaryRadius)
                : base(centerPlateOfX, centerPlateOfY, centerPlateOfZ, imaginaryRadius)
        {
            matrix = new double[4, 3];

            //expending plate of tetrahedron with polar system coordinates as 2PI/3 4PI/3 and 6PI/3 ( or 0) ->
            // the equilateral triangle on plate

            for (double tetaAngular = 0, i = 0; tetaAngular < 2 * Math.PI; tetaAngular += 2 * Math.PI / 3, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + imaginaryRadius * Math.Cos(tetaAngular);
                matrix[(int)i, 1] = centerPlateOfY + imaginaryRadius * Math.Sin(tetaAngular);
                matrix[(int)i, 2] = centerPlateOfZ;
            }

            // expand last top point with default decart system

            matrix[3, 0] = centerPlateX;
            matrix[3, 1] = centerPlateY;
            matrix[3, 2] = centerPlateOfZ + imaginaryRadius;
        }


        public override void DrawSolid(Graphics g, double coef, double alpha)
        {
            var points = this.ToPointArray(coef, alpha);

            for (int i = 0; i < 2; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[3].X, points[3].Y);
            }
            g.DrawLine(Pens.Aqua, points[0].X, points[0].Y, points[2].X, points[2].Y);
            g.DrawLine(Pens.Aqua, points[2].X, points[2].Y, points[3].X, points[3].Y);
        }

    }
}
