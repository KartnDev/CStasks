using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Solids
{
    public class Octahedron : BasePlatonicSolid, ISolid
    {

        public Octahedron(int centerPlateOfX, int centerPlateOfY, int centerPlateOfZ, int imaginaryRadius)
                : base(centerPlateOfX, centerPlateOfY, centerPlateOfZ, imaginaryRadius)
        {

            matrix = new double[6, 3];


            for (double teta = 0, i = 1; teta < Math.PI * 2; teta += Math.PI / 2, i++)
            {
                matrix[(int)i, 0] = centerPlateOfX + imaginaryRadius * Math.Cos(teta);
                matrix[(int)i, 1] = centerPlateOfY + imaginaryRadius * Math.Sin(teta);
                matrix[(int)i, 2] = centerPlateOfZ;
            }

            matrix[0, 0] = centerPlateOfX; 
            matrix[0, 1] = centerPlateOfY; 
            matrix[0, 2] = imaginaryRadius;

            matrix[5, 0] = centerPlateOfX; 
            matrix[5, 1] = centerPlateOfY; 
            matrix[5, 2] = -imaginaryRadius;
        }

        public override void DrawSolid(Graphics g, double coef, double alpha)
        {
            var points = this.ToPointArray(coef, alpha);


            for (int i = 1; i <(int)(points.GetLength(0) - 1); i++)
            {
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[5].X, points[5].Y);
                g.DrawLine(Pens.Aqua, points[i].X, points[i].Y, points[0].X, points[0].Y);
            }
            
                g.DrawLine(Pens.Aqua, points[1].X, points[1].Y, points[4].X, points[4].Y);
                //g.DrawLine(Pens.Aqua, points[1].X, points[1].Y, points[4].X, points[4].Y);
        }

    }
}
