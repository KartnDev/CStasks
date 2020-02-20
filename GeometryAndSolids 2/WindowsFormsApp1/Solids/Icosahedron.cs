using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Solids
{
    public class Icosahedron : BasePlatonicSolid, ISolid
    {

        public Icosahedron(int centerPlateOfX, int centerPlateOfY, int centerPlateOfZ, int imaginaryRadius)
                : base(centerPlateOfX, centerPlateOfY, centerPlateOfZ, imaginaryRadius)
        {
            matrix = new double[12, 3];

            //expending plate of tetrahedron with polar system coordinates as 2PI/3 4PI/3 and 6PI/3 ( or 0) ->
            // the equilateral triangle on plate

            for (double tetaAngular = 0, i = 0; tetaAngular < 2 * Math.PI; tetaAngular += 2 * Math.PI / 3, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + imaginaryRadius * Math.Cos(tetaAngular);
                matrix[(int)i, 1] = centerPlateOfY + imaginaryRadius * Math.Sin(tetaAngular);
                matrix[(int)i, 2] = centerPlateOfZ;
            }
            for (double tetaAngular = 0, i = 3; tetaAngular < 2 * Math.PI; tetaAngular += 2 * Math.PI / 3, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + 1.5 *imaginaryRadius * Math.Cos(tetaAngular + Math.PI / 3);
                matrix[(int)i, 1] = centerPlateOfY + 1.5 * imaginaryRadius * Math.Sin(tetaAngular + Math.PI / 3);
                matrix[(int)i, 2] = centerPlateOfZ + imaginaryRadius * 0.9;
            }
            for (double tetaAngular = 0, i = 6; tetaAngular < 2 * Math.PI; tetaAngular += 2 * Math.PI / 3, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + 1.5 * imaginaryRadius * Math.Cos(tetaAngular);
                matrix[(int)i, 1] = centerPlateOfY + 1.5 * imaginaryRadius * Math.Sin(tetaAngular);
                matrix[(int)i, 2] = centerPlateOfZ + imaginaryRadius * 1.35;
            }
            for (double tetaAngular = 0, i = 9; tetaAngular < 2 * Math.PI; tetaAngular += 2 * Math.PI / 3, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + imaginaryRadius * Math.Cos(tetaAngular + Math.PI / 3);
                matrix[(int)i, 1] = centerPlateOfY + imaginaryRadius * Math.Sin(tetaAngular + Math.PI / 3);
                matrix[(int)i, 2] = centerPlateOfZ + imaginaryRadius * 2.35;
            }

            // expand last top point with default decart system


        }


        public override void DrawSolid(Graphics g, double coef, double alpha)
        {
            var points = this.ToPointArray(coef, alpha);

            for (int i = 0; i < 2; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }
            for (int i = 9; i < 11; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }

            g.DrawLine(Pens.Aqua, points[0].X, points[0].Y, points[2].X, points[2].Y);
            g.DrawLine(Pens.Aqua, points[9].X, points[9].Y, points[11].X, points[11].Y);

            // bais ands

            for (int i = 0; i < 12; i+=6)
            {
                g.DrawLine(Pens.Aqua, points[1 + i].X, points[1 + i].Y, points[3 + i].X, points[3 + i].Y);
                g.DrawLine(Pens.Aqua, points[1 + i].X, points[1 + i].Y, points[4 + i].X, points[4 + i].Y);
                g.DrawLine(Pens.Aqua, points[2 + i].X, points[2 + i].Y, points[4 + i].X, points[4 + i].Y);
                g.DrawLine(Pens.Aqua, points[2 + i].X, points[2 + i].Y, points[5 + i].X, points[5 + i].Y);
                g.DrawLine(Pens.Aqua, points[0 + i].X, points[0 + i].Y, points[5 + i].X, points[5 + i].Y);
                g.DrawLine(Pens.Aqua, points[0 + i].X, points[0 + i].Y, points[3 + i].X, points[3 + i].Y);
            }
            g.DrawLine(Pens.Aqua, points[3].X, points[3].Y, points[7].X, points[7].Y);
            g.DrawLine(Pens.Aqua, points[4].X, points[4].Y, points[7].X, points[7].Y);
            g.DrawLine(Pens.Aqua, points[4].X, points[4].Y, points[8].X, points[8].Y);
            g.DrawLine(Pens.Aqua, points[5].X, points[5].Y, points[8].X, points[8].Y);
            g.DrawLine(Pens.Aqua, points[5].X, points[5].Y, points[6].X, points[6].Y);
            g.DrawLine(Pens.Aqua, points[3].X, points[3].Y, points[6].X, points[6].Y);

            for (int i = 0; i < 2; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 6].X, points[i + 6].Y);
            }
            for(int i = 3; i < 5; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 6].X, points[i + 6].Y);
            }
            g.DrawLine(Pens.Aqua, points[2].X, points[2].Y, points[8].X, points[8].Y);
            g.DrawLine(Pens.Aqua, points[5].X, points[5].Y, points[11].X, points[11].Y);
        }

    }
}
