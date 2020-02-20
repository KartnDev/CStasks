using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Solids
{
    public interface ISolid
    {
        double[,] GetMatrix();
        void DrawSolid(Graphics g, double coef, double alpha);
        void RotateByX(double angle);
        void RotateByY(double angle);
        void RotateByZ(double angle);
        void Scew(double scale);
        void Scale(double scaleX, double scaleY, double scaleZ);
        void Shift(double dx, double dy, double dz);
        Point[] ToPointArray(double coef, double angel);

    }
}
