using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Solids
{
    public class Dodecahedron : BasePlatonicSolid, ISolid
    {

        public Dodecahedron(int centerPlateOfX, int centerPlateOfY, int centerPlateOfZ, int imaginaryRadius)
                : base(centerPlateOfX, centerPlateOfY, centerPlateOfZ, imaginaryRadius)
        {
            matrix = new double[20, 3];

            //expending plate of tetrahedron with polar system coordinates as 2PI/3 4PI/3 and 6PI/3 ( or 0) ->
            // the equilateral triangle on plate

            for (double tetaAngular = 0, i = 0; tetaAngular < 2 * Math.PI; tetaAngular += 2 * Math.PI / 5, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + imaginaryRadius * Math.Cos(tetaAngular);
                matrix[(int)i, 1] = centerPlateOfY + imaginaryRadius * Math.Sin(tetaAngular);
                matrix[(int)i, 2] = centerPlateOfZ;
            }
            for (double tetaAngular = 0, i = 5; tetaAngular < 2 * Math.PI; tetaAngular += 2 * Math.PI / 5, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + 1.5 * imaginaryRadius * Math.Cos(tetaAngular);
                matrix[(int)i, 1] = centerPlateOfY + 1.5*imaginaryRadius * Math.Sin(tetaAngular);
                matrix[(int)i, 2] = centerPlateOfZ + imaginaryRadius * 0.9; ;
            }
            for (double tetaAngular = 0, i = 10; tetaAngular < 2 * Math.PI; tetaAngular += 2 * Math.PI / 5, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + 1.5 * imaginaryRadius * Math.Cos(tetaAngular + Math.PI / 5);
                matrix[(int)i, 1] = centerPlateOfY + 1.5 * imaginaryRadius * Math.Sin(tetaAngular + Math.PI / 5);
                matrix[(int)i, 2] = centerPlateOfZ + imaginaryRadius * 1.35; ;
            }
            for (double tetaAngular = 0, i = 15; tetaAngular < 2 * Math.PI; tetaAngular += 2 * Math.PI / 5, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + imaginaryRadius * Math.Cos(tetaAngular + Math.PI / 5);
                matrix[(int)i, 1] = centerPlateOfY + imaginaryRadius * Math.Sin(tetaAngular + Math.PI / 5);
                matrix[(int)i, 2] = centerPlateOfZ + imaginaryRadius * 2.35; ;
            }

            // expand last top point with default decart system


        }


        public override void DrawSolid(Graphics g, double coef, double alpha)
        {
            var points = this.ToPointArray(coef, alpha);

            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }
            for (int i = 15; i < 19; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }

            g.DrawLine(Pens.Aqua, points[0].X, points[0].Y, points[4].X, points[4].Y);
            g.DrawLine(Pens.Aqua, points[15].X, points[15].Y, points[19].X, points[19].Y);

            //base ends
            for (int lvl = 0; lvl < 20; lvl += 10)
            {
                for (int i = 0; i < 4; i++)
                {
                    g.DrawLine(Pens.Aqua, points[i + lvl].X, points[i + lvl].Y, points[i + 5 + lvl].X, points[i + 5 + lvl].Y);
                }
                g.DrawLine(Pens.Aqua, points[4 + lvl].X, points[4 + lvl].Y, points[9 + lvl].X, points[9 + lvl].Y);
            }

            for (int i = 5; i < 9; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i+5].X, points[i+5].Y);
            }
            for (int i = 6; i < 10; i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 4].X, points[i + 4].Y);
            }
            g.DrawLine(Pens.Aqua, points[9].X, points[9].Y, points[14].X, points[14].Y);
            g.DrawLine(Pens.Aqua, points[5].X, points[5].Y, points[14].X, points[14].Y);

        }

    }
}
