using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Solids
{
    public class ChairSolid : BasePlatonicSolid
    {
        private Pen solidPen = new Pen(new SolidBrush(Color.Blue), 2);

        public ChairSolid() : base(0, 0, 0, 0)
        {
            matrix = new double[32, 3];
            matrix[0, 0] = 0; matrix[0, 1] = 0; matrix[0, 2] = 0;
            matrix[1, 0] = 10; matrix[1, 1] = 0; matrix[1, 2] = 0;
            matrix[2, 0] = 0; matrix[2, 1] = 10; matrix[2, 2] = 0;
            matrix[3, 0] = 10; matrix[3, 1] = 10; matrix[3, 2] = 0;

            matrix[4, 0] = 40; matrix[4, 1] = 0; matrix[4, 2] = 0;
            matrix[5, 0] = 40; matrix[5, 1] = 10; matrix[5, 2] = 0;
            matrix[6, 0] = 50; matrix[6, 1] = 0; matrix[6, 2] = 0;
            matrix[7, 0] = 50; matrix[7, 1] = 10; matrix[7, 2] = 0;

            matrix[8, 0] = 0; matrix[8, 1] = 40; matrix[8, 2] = 0;
            matrix[9, 0] = 10; matrix[9, 1] = 40; matrix[9, 2] = 0;
            matrix[10, 0] = 0; matrix[10, 1] = 50; matrix[10, 2] = 0;
            matrix[11, 0] = 10; matrix[11, 1] = 50; matrix[11, 2] = 0;

            matrix[12, 0] = 40; matrix[12, 1] = 40; matrix[12, 2] = 0;
            matrix[13, 0] = 40; matrix[13, 1] = 50; matrix[13, 2] = 0;
            matrix[14, 0] = 50; matrix[14, 1] = 40; matrix[14, 2] = 0;
            matrix[15, 0] = 50; matrix[15, 1] = 50; matrix[15, 2] = 0;

            matrix[16, 0] = 10; matrix[16, 1] = 10; matrix[16, 2] = 40;
            matrix[17, 0] = 10; matrix[17, 1] = 40; matrix[17, 2] = 40;
            matrix[18, 0] = 40; matrix[18, 1] = 10; matrix[18, 2] = 40;
            matrix[19, 0] = 40; matrix[19, 1] = 40; matrix[19, 2] = 40;

            matrix[20, 0] = 0; matrix[20, 1] = 0; matrix[20, 2] = 50;
            matrix[21, 0] = 0; matrix[21, 1] = 50; matrix[21, 2] = 50;
            matrix[22, 0] = 50; matrix[22, 1] = 0; matrix[22, 2] = 50;
            matrix[23, 0] = 50; matrix[23, 1] = 50; matrix[23, 2] = 50;

            matrix[24, 0] = 10; matrix[24, 1] = 0; matrix[24, 2] = 40;
            matrix[25, 0] = 0; matrix[25, 1] = 10; matrix[25, 2] = 40;

            matrix[26, 0] = 40; matrix[26, 1] = 0; matrix[26, 2] = 40;
            matrix[27, 0] = 50; matrix[27, 1] = 10; matrix[27, 2] = 40;

            matrix[28, 0] = 0; matrix[28, 1] = 40; matrix[28, 2] = 40;
            matrix[29, 0] = 10; matrix[29, 1] = 50; matrix[29, 2] = 40;

            matrix[30, 0] = 40; matrix[30, 1] = 50; matrix[30, 2] = 40;
            matrix[31, 0] = 50; matrix[31, 1] = 40; matrix[31, 2] = 40;

        }
        public Point3D[] ToPoint3DArray()
        {
            Point3D[] points = new Point3D[24];
            for (int i = 0; i < 24; i++)
            {
                points[i] = new Point3D(matrix[i, 0], matrix[i, 1], matrix[i, 2]);
            }
            return points;
        }

        public override void DrawSolid(Graphics g, double coef, double alpha)
        {
            var points = this.ToPointArray(coef, alpha);
            for (int i = 0; i < 16; i += 4)
            {
                g.DrawLine(solidPen, points[0 + i], points[1 + i]);
                g.DrawLine(solidPen, points[1 + i], points[3 + i]);
                g.DrawLine(solidPen, points[3 + i], points[2 + i]);
                g.DrawLine(solidPen, points[2 + i], points[0 + i]);
            }

            g.DrawLine(solidPen, points[0 + 16], points[1 + 16]);
            g.DrawLine(solidPen, points[1 + 16], points[3 + 16]);
            g.DrawLine(solidPen, points[3 + 16], points[2 + 16]);
            g.DrawLine(solidPen, points[2 + 16], points[0 + 16]);

            g.DrawLine(solidPen, points[3], points[16]);
            g.DrawLine(solidPen, points[5], points[18]);
            g.DrawLine(solidPen, points[9], points[17]);
            g.DrawLine(solidPen, points[12], points[19]);

            g.DrawLine(solidPen, points[20], points[21]);
            g.DrawLine(solidPen, points[21], points[23]);
            g.DrawLine(solidPen, points[23], points[22]);
            g.DrawLine(solidPen, points[22], points[20]);

            g.DrawLine(solidPen, points[0], points[20]);
            g.DrawLine(solidPen, points[6], points[22]);
            g.DrawLine(solidPen, points[10], points[21]);
            g.DrawLine(solidPen, points[15], points[23]);

            g.DrawLine(solidPen, points[1], points[24]);
            g.DrawLine(solidPen, points[2], points[25]);

            g.DrawLine(solidPen, points[4], points[26]);
            g.DrawLine(solidPen, points[7], points[27]);

            g.DrawLine(solidPen, points[8], points[28]);
            g.DrawLine(solidPen, points[11], points[29]);

            g.DrawLine(solidPen, points[13], points[30]);
            g.DrawLine(solidPen, points[14], points[31]);

            g.DrawLine(solidPen, points[26], points[24]);
            g.DrawLine(solidPen, points[25], points[28]);
            g.DrawLine(solidPen, points[29], points[30]);
            g.DrawLine(solidPen, points[31], points[27]);
        }
    }
}
